namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Booths.Contracts;

    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> booths;
        public BoothRepository()
        {
            booths= new List<IBooth>();
        }
        public IReadOnlyCollection<IBooth> Models 
            => booths.AsReadOnly();
        public void AddModel(IBooth booth)
            => booths.Add(booth);
    }
}
