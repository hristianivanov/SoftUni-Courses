namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Enums;
    using Interfaces;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly ICollection<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName,
            decimal salary, Corps corps, ICollection<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs
            => (IReadOnlyCollection<IRepair>)repairs;

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder
                .AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (IRepair repair in Repairs)
                builder.AppendLine($"  {repair}");

            return builder.ToString().TrimEnd();
        }
    }
}