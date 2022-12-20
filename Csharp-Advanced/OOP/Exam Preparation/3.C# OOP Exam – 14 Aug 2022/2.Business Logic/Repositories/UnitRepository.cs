namespace PlanetWars.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private ICollection<IMilitaryUnit> unitRepository;
        public UnitRepository()
        {
            unitRepository = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models
            => (IReadOnlyCollection<IMilitaryUnit>)unitRepository;
        public IMilitaryUnit FindByName(string name)
            => unitRepository.FirstOrDefault(x => x.GetType().Name == name);

        public void AddItem(IMilitaryUnit model)
            => unitRepository.Add(model);

        public bool RemoveItem(string name)
            => unitRepository.Remove(FindByName(name));
    }
}
