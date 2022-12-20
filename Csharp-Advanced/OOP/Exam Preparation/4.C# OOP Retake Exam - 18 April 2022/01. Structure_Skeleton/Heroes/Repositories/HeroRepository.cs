namespace Heroes.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;
        public HeroRepository()
        {
            heroes = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models
            => heroes.AsReadOnly();
        public void Add(IHero model)
            => heroes.Add(model);
        public IHero FindByName(string name)
            => heroes.FirstOrDefault(x => x.Name == name);
        public bool Remove(IHero model)
            => heroes.Remove(model);
    }
}
