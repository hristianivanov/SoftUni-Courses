namespace ChristmasPastryShop.Models.Cocktails
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        public Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
            this.Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }
        public string Size { get; private set; }
        public double Price
        {
            get => price;
            private set
            {
                if (Size == "Large")
                {
                    price = value;
                }
                else if (Size == "Middle")
                {
                    price = value * 2 / 3;
                }
                else if (Size == "Small")
                {
                    price = value / 3;
                }
            }
        }
        public override string ToString()
            => $"{Name} ({Size}) - {Price:f2} lv";
    }
}
