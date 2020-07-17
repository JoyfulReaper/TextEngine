using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TextEngine;

namespace TextEngineTests
{
    [TestClass]
    public class CurrencyTest
    {
        int value = 1; 

        [TestMethod]
        public void CurrencyName()
        {
            Currency c = new Currency("Silver", value);
            Assert.AreEqual("Silver", c.Name);
        }

        [TestMethod]
        public void ValueEqualToConstructedValue()
        {
            Currency c = new Currency("Silver", value);
            Assert.AreEqual(value, c.Value);
        }

        [TestMethod]
        public void ValueCannotBeNegatice()
        {
            Currency c = new Currency("Silver", value);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => c.Value = -1);
        }
    }
}
