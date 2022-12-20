namespace Gym.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Equipment.Contracts;
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> equipment;
        public EquipmentRepository()
        {
            this.equipment = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models
            => this.equipment.AsReadOnly();
        public void Add(IEquipment model)
            => this.equipment.Add(model);
        public IEquipment FindByType(string type)
            => this.equipment.FirstOrDefault(x => x.GetType().Name == type);
        public bool Remove(IEquipment model)
            => this.equipment.Remove(model);
    }
}
