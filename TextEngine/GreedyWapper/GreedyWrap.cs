/*
MIT License

Copyright(c) 2020 Kyle Givler

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
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

namespace Kgivler.GreedyWrap
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
