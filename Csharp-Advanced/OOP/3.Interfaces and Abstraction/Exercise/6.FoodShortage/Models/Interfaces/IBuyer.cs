namespace FoodShortage.Models.Interfaces
{
    public interface IBuyer
    {
        int Food { get;}
        string Name { get;}
        void BuyFood();
    }
}
