namespace NavalVessels.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    public abstract class Vessel : IVessel
    {
        private string name;
        private double initialArmourThickness;
        private ICaptain captain;
        private List<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            initialArmourThickness = armorThickness;
            targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                name = value;
            }
        }
        public ICaptain Captain
        {
            get => captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
                captain = value;
            }
        }
        public double ArmorThickness { get; set; }
        public double MainWeaponCaliber { get; protected set; }
        public double Speed { get; protected set; }
        public ICollection<string> Targets
            => targets.AsReadOnly();
        public void Attack(IVessel target)
        {
            if (target == null)
                throw new NullReferenceException("Target cannot be null.");
            if (target.ArmorThickness - MainWeaponCaliber < 0)
                target.ArmorThickness = 0;
            else
                target.ArmorThickness -= MainWeaponCaliber;
            targets.Add(target.Name);
        }
        public void RepairVessel()
            =>ArmorThickness = initialArmourThickness;
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"- {Name}")
            .AppendLine($" *Type: {GetType().Name}")
            .AppendLine($" *Armor thickness: {ArmorThickness}")
            .AppendLine($" *Main weapon caliber: {MainWeaponCaliber}")
            .AppendLine($" *Speed: {Speed} knots")
            .AppendLine($" *Targets: {(Targets.Count == 0 ? "None" : string.Join(", ", Targets))}");

            return stringBuilder.ToString().Trim();
        }
    }
}
