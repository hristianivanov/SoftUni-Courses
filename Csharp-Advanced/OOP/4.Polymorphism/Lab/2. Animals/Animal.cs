namespace Animals
{
    public abstract class Animal
    {
        protected Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        protected string Name { get; }
        protected string FavouriteFood { get;  }
        public virtual string ExplainSelf() => $"I am {Name} and my fovourite food is {FavouriteFood}";
    }
}
