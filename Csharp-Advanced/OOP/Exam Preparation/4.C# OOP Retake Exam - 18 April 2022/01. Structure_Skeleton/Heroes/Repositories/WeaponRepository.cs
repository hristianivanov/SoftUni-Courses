namespace Heroes.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;
        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models
            => weapons.AsReadOnly();
        public void Add(IWeapon model)
            => weapons.Add(model);
        public IWeapon FindByName(string name)
            => weapons.FirstOrDefault(x => x.Name == name);
        public bool Remove(IWeapon model)
            => weapons.Remove(model);
    }
}
