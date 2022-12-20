namespace ChristmasPastryShop.Models.Booths
{
    using System;
    using System.Text;

    using Contracts;
    using Cocktails.Contracts;
    using Delicacies.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Booth : IBooth
    {
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;

            delicacyMenu = new DelicacyRepository();
            cocktailMenu = new CocktailRepository();
        }
        public int BoothId { get; private set; }
        public double CurrentBill { get; private set; }
        public double Turnover { get; private set; }
        public bool IsReserved { get; private set; }
        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }
        public IRepository<IDelicacy> DelicacyMenu
            => delicacyMenu;
        public IRepository<ICocktail> CocktailMenu
            => cocktailMenu;
        public void ChangeStatus()
            => IsReserved = !IsReserved;
        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }
        public void UpdateCurrentBill(double amount)
            => CurrentBill += amount;
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Booth: {BoothId}");
            stringBuilder.AppendLine($"Capacity: {Capacity}");
            stringBuilder.AppendLine($"Turnover: {Turnover:f2} lv");
            stringBuilder.AppendLine("-Cocktail menu:");
            foreach (var item in cocktailMenu.Models)
                stringBuilder.AppendLine($"--{item}");
            stringBuilder.AppendLine("-Delicacy menu:");
            foreach (var item in delicacyMenu.Models)
                stringBuilder.AppendLine($"--{item}");

            return stringBuilder.ToString().Trim();
        }
    }
}
