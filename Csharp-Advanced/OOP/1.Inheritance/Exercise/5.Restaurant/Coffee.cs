using System;
using System.Collections.Generic;
using System.Text;

namespace _5.Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50;
        private const decimal COFFEE_PRICE = 3.50M;
        public Coffee(string name,double caffeine) : base(name, COFFEE_PRICE, COFFEE_MILLILITERS)
        {
            this.Caffeine = caffeine;
        }
        public double Caffeine { get; set; }

    }
}
