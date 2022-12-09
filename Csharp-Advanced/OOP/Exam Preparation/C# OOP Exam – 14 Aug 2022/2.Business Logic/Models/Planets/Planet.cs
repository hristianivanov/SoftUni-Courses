namespace PlanetWars.Models.Planets
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Models.Weapons;
    using Planets.Contracts;
    using MilitaryUnits;
    using MilitaryUnits.Contracts;
    using Weapons.Contracts;
    using Utilities.Messages;
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private List<IMilitaryUnit> army;
        private List<IWeapon> weapons;

        private double totalAmmount;
        private double sumOfEndurances;
        private double sumOfWeaponDestructionLevel;

        private Planet()
        {
            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }
        public Planet(string name, double budget)
            : this()
        {
            this.Name = name;
            this.Budget = budget;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                sumOfEndurances = army.Sum(x => x.EnduranceLevel);
                sumOfWeaponDestructionLevel = weapons.Sum(x => x.DestructionLevel);

                totalAmmount = sumOfEndurances + sumOfWeaponDestructionLevel;

                if (army.Any(x => x.GetType() == typeof(AnonymousImpactUnit)))
                    totalAmmount += totalAmmount * 0.3;

                if (weapons.Any(x => x.GetType() == typeof(NuclearWeapon)))
                    totalAmmount += totalAmmount * 0.45;


                return Math.Round(totalAmmount, 3);
            }
            private set => this.totalAmmount = value;
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
            => army.AsReadOnly();

        public IReadOnlyCollection<IWeapon> Weapons
            => weapons.AsReadOnly();

        public void AddUnit(IMilitaryUnit unit)
        {
            army.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }
        public void Spend(double amount)
        {
            if (Budget < amount)
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);

            Budget -= amount;
        }
        public void Profit(double amount)
        {
            Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string forcesOutput = army.Any() ? string.Join(", ", army.Select(x => x.GetType().Name)) : "No units";
            string combatOutput = weapons.Any() ? string.Join(", ", weapons.Select(x => x.GetType().Name)) : "No weapons";

            sb.AppendLine($"Planet: {Name}")
                .AppendLine($"--Budget: {Budget} billion QUID")
                .AppendLine($"--Forces: {forcesOutput}")
                .AppendLine($"--Combat equipment: {combatOutput}")
                .AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void TrainArmy()
            => army.ForEach(a => a.IncreaseEndurance());

    }
}
