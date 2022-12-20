namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models.Weapons.Contracts;
    using Repositories.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> weaponsRepository;
        private WeaponRepository()
        {
            weaponsRepository = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models
            => (IReadOnlyCollection<IWeapon>)weaponsRepository;
        public IWeapon FindByName(string name)
            => weaponsRepository.FirstOrDefault(x => x.GetType().Name == name);

        public void AddItem(IWeapon model)
            => weaponsRepository.Add(model);
        public bool RemoveItem(string name)
            => weaponsRepository.Remove(FindByName(name));
    }
}
