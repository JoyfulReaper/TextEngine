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

using System;
using System.Collections.Generic;
using TextEngine.MapItems;

namespace TextEngine
{
    class Wallet
    {
        private Dictionary<Currency, int> wallet = new Dictionary<Currency, int>();

        /// <summary>
        /// Add Currency to this Wallet
        /// </summary>
        /// <param name="currency">The Currency to add</param>
        /// <param name="amount">The amount of the Currency to add</param>
        public void AddCurrency(Currency currency, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Amount must be > 0");

            if (wallet.ContainsKey(currency))
                wallet[currency] += amount;
            else
                wallet.Add(currency, amount);
        }

        /// <summary>
        /// Remove Currency from this walletr
        /// </summary>
        /// <param name="currency">The Currrency to remove</param>
        /// <param name="amount">The amount of Curreny to remove</param>
        public void RemoveCurrency(Currency currency, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Amount must be > 0");

            if (!wallet.ContainsKey(currency))
                throw new InvalidItemException($"The wallet does not contain any {currency.Name}");

            if (amount > wallet[currency])
                throw new CurrencyException($"The wallet does not have {amount} of {currency.Name}. The wallet contains: {wallet[currency]}");

            wallet[currency] -= amount;
        }

        /// <summary>
        /// Reterive a List of Currency in the Wallet
        /// </summary>
        /// <returns>List of Currencies</returns>
        public List<Currency> GetCurrencies()
        {
            List<Currency> currencies = new List<Currency>();
            foreach (KeyValuePair<Currency, int> entry in wallet)
                currencies.Add(entry.Key);

            return currencies;
        }
    }
}
