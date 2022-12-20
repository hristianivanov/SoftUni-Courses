namespace Gym.Models.Gyms
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Athletes.Contracts;
    using Equipment.Contracts;
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Gym name cannot be null or empty.");
                name = value;
            }
        }
        public int Capacity { get; private set; }
        public ICollection<IEquipment> Equipment
            => equipment.AsReadOnly();
        public double EquipmentWeight
            => equipment.Sum(x => x.Weight);
        public ICollection<IAthlete> Athletes
            => athletes.AsReadOnly();
        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count + 1 > Capacity)
                throw new InvalidOperationException("Not enough space in the gym.");
            athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete)
            => athletes.Remove(athlete);
        public void AddEquipment(IEquipment equipment)
            => this.equipment.Add(equipment);
        public void Exercise()
            => athletes.ForEach(x => x.Exercise());
        public string GymInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Name} is a {GetType().Name}:")
                .AppendLine($"Athletes: {(athletes.Count == 0 ? "No athletes" : string.Join(", ", athletes.Select(x => x.FullName)))}")
                .AppendLine($"Equipment total count: {this.equipment.Count}")
                .AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return stringBuilder.ToString().Trim();
        }


    }
}
