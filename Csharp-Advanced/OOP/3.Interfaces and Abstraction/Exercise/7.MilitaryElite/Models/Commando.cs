namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Enums;
    using Interfaces;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly ICollection<IMission> missions;

        public Commando(int id, string firstName, string lastName,
            decimal salary, Corps corps, ICollection<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions
            => (IReadOnlyCollection<IMission>)missions;

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder
                .AppendLine(base.ToString())
                .AppendLine("Missions:");
            foreach (IMission mission in Missions)
                builder.AppendLine($"  {mission}");

            return builder.ToString().TrimEnd();
        }
    }
}