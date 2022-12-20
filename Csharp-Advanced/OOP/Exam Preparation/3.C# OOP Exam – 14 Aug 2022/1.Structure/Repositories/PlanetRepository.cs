namespace PlanetWars.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Planets.Contracts;
    public class PlanetRepository : IRepository<IPlanet>
    {
        private ICollection<IPlanet> planetRepository;

        private PlanetRepository()
        {
            planetRepository = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models
            => (IReadOnlyCollection<IPlanet>)planetRepository;

        public void AddItem(IPlanet model)
            => planetRepository.Add(model);

        public IPlanet FindByName(string name)
            => planetRepository.FirstOrDefault(x => x.Name == name);

        public bool RemoveItem(string name)
            => planetRepository.Remove(FindByName(name));
    }
}
