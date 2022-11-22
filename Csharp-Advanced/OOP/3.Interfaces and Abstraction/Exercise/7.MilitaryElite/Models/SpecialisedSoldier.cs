namespace MilitaryElite.Models
{
    using System;

    using Enums;
    using Interfaces;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName,
            decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Corps: {this.Corps}";
        }
    }
}