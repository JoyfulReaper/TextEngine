using System;
using System.Collections.Generic;
using System.Text;

namespace TextEngine
{
    class Currency
    {
        public String Name { get; set; } 

        public decimal Amount
        {
            get => amount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Amount must be >= 0");
                amount = value;
            }
        }
        
        public decimal Value
        {
            get => value;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Value must be >= 0");
                this.value = value;
            }
        }

        decimal value;
        decimal amount;

        public Currency(string name, decimal amount, decimal value)
        {
            this.Name = name;
            this.Amount = amount;
            this.value = value;
        }
    }
}
