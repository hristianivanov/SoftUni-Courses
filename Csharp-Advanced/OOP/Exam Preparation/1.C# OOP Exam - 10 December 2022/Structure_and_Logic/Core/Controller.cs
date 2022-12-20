namespace ChristmasPastryShop.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Models.Booths;
    using Models.Cocktails;
    using Models.Delicacies;
    using Models.Booths.Contracts;
    using Models.Cocktails.Contracts;
    using Models.Delicacies.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IBooth> boothRepository;
        public Controller()
        {
            boothRepository = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothId = boothRepository.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);
            boothRepository.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = boothRepository.Models.Single(x => x.BoothId == boothId);
            IDelicacy delicacy = null;
            switch (delicacyTypeName)
            {
                case nameof(Stolen): delicacy = new Stolen(delicacyName); break;
                case nameof(Gingerbread): delicacy = new Gingerbread(delicacyName); break;
                default: return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            if (booth.DelicacyMenu.Models.Any(x => x.Name == delicacyName))
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }
        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = boothRepository.Models.Single(x => x.BoothId == boothId);
            ICocktail cocktail = null;
            switch (cocktailTypeName)
            {
                case nameof(Hibernation): cocktail = new Hibernation(cocktailName, size); break;
                case nameof(MulledWine): cocktail = new MulledWine(cocktailName, size); break;
                default: return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            if (!new string[] { "Large", "Middle", "Small" }.Contains(size))
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            if (booth.CocktailMenu.Models.Any(x => x.Name == cocktailName && x.Size == size))
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);

            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }
        public string ReserveBooth(int countOfPeople)
        {
            var orderedBooths = boothRepository.Models
                .Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity)
                .ThenByDescending(x => x.BoothId)
                .ToList();
            IBooth currBooth = orderedBooths.FirstOrDefault();
            if (currBooth == null && orderedBooths.Count == 0)
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            currBooth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, currBooth.BoothId, countOfPeople);
        }
        public string TryOrder(int boothId, string order)
        {
            string[] orderArgs = order.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderArgs[0];
            string itemName = orderArgs[1];
            int pieces = int.Parse(orderArgs[2]);
            string size = null;
            if (orderArgs.Length == 4)
                size = orderArgs[3];

            IBooth booth = boothRepository.Models.Single(x => x.BoothId == boothId);

            ICocktail cocktail = null;
            IDelicacy delicacy = null;

            switch (itemTypeName)
            {
                case nameof(Stolen): delicacy = booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == itemName); break;
                case nameof(Gingerbread): delicacy = booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == itemName); break;
                case nameof(Hibernation): cocktail = booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName); break;
                case nameof(MulledWine): cocktail = booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName); break;
                default: return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (delicacy == null && cocktail == null)
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);

            if (cocktail != null)
            {
                if (cocktail.Size != size)
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
            }
            if (delicacy != null)
            {
                if (delicacy.GetType().Name != itemTypeName)
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
            }

            booth.UpdateCurrentBill(delicacy == null ? cocktail.Price * pieces : delicacy.Price * pieces);
            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, pieces, itemName);

        }
        public string LeaveBooth(int boothId)
        {
            IBooth booth = boothRepository.Models.Single(x => x.BoothId == boothId);
            double currBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            return $"Bill {currBill:f2} lv" +
                Environment.NewLine +
                $"Booth {boothId} is now available!";
        }
        public string BoothReport(int boothId)
            => $"{boothRepository.Models.Single(b => b.BoothId == boothId)}";
    }
}
