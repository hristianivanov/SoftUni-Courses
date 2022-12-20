namespace ChristmasPastryShop.Models.Delicacies
{
    using System;

    using Contracts;
    using Utilities.Messages;
    public abstract class Delicacy : IDelicacy
    {
        private string name;
        public Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
            Price = price;
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
        public double Price { get; private set; }
        public override string ToString()
            => $"{Name} - {Price:f2} lv";
    }
}

