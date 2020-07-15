/*
 *   GreedyWrap: GreedyWrap.cs
 *   Copyright (C) 2020 Kyle Givler
 * 
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 * 
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *   GNU General Public License for more details.
 * 
 *   You should have received a copy of the GNU General Public License
 *   along with this program. If not, see <http://www.gnu.org/licenses/>.
 * 
 */

/**
 * @file GreedyWrap.cs
 * @author Kyle Givler
 * 
 * Greedy word wrapping class
 * Ported from my C++ version
 */

using System;
using System.Text;

namespace Kgivler
{
    public class GreedyWrap
    {
        public int LineWidth { get; set; }
        public ushort TabWidth { get; set; } = 4;
        public bool WrapWordsLongerThanLineWidth { get; set; } = false; // If true will split words with a length greater than lineWidth value

        private int spaceLeft;
        private StringBuilder text;
        private const ushort SPACE_WIDTH = 1;

        public GreedyWrap(int lineWidth = 80, bool wrapWordsLongerThanLineWidth = false)
        {
            LineWidth = lineWidth;
            WrapWordsLongerThanLineWidth = wrapWordsLongerThanLineWidth;
        }

        public string LineWrap(string input)
        {
            if (input == null || input.Length <= 0)
                return "";

            text = new StringBuilder(input);
            spaceLeft = LineWidth;
            string word;
            StringBuilder output = new StringBuilder();

            while (text.Length != 0)
            {
                word = getNextWord();
                if(word.Length + SPACE_WIDTH > spaceLeft)
                {
                    output.Append(Environment.NewLine + word + " ");
                    spaceLeft = LineWidth - (word.Length + SPACE_WIDTH);
                }
                else
                {
                    spaceLeft -= word.Length + SPACE_WIDTH;
                    output.Append(word + " ");
                }
            }

            output.Remove(output.Length - 1, 1);
            return output.ToString();
        }

        // Returns the next word in the text
        private string getNextWord()
        {
            StringBuilder word = new StringBuilder();
            char letter;
            ushort realLength = 0;

            for (ushort pos = 0; pos < text.Length; pos++)
            {
                letter = text[pos];
                if (letter == '\n')
                    spaceLeft = LineWidth;

                if (letter == '\t')
                { 
                    for (ushort i = 1; i < TabWidth; i++)
                        word.Append(' ');

                    realLength++;
                    break;
                }

                if (letter == ' ')
                {
                    text.Remove(0, 1);
                    break;
                }

                // word is longer than the LineWidth, AND we want to insert a '-' and wrap it
                if (word.Length == LineWidth -1 && WrapWordsLongerThanLineWidth)
                {
                    if (!char.IsPunctuation(text[pos +1]) && !char.IsWhiteSpace(text[pos + 1]))
                        word.Append('-');
                    else
                    {
                        word.Append(letter);
                        realLength++;
                    }
                    break;
                }

                word.Append(letter);
                realLength++;
            }

            text.Remove(0, realLength);
            return word.ToString();
        }
    }
}
