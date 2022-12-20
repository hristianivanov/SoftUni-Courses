namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Delicacies.Contracts;

    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> delicacies;
        public DelicacyRepository()
        {
            delicacies= new List<IDelicacy>();
        }
        public IReadOnlyCollection<IDelicacy> Models 
            => delicacies.AsReadOnly();
        public void AddModel(IDelicacy delicacy)
            =>delicacies.Add(delicacy);
    }
}
