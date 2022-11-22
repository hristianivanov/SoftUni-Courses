namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Interfaces;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly ICollection<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName,
            decimal salary, ICollection<IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates
            => (IReadOnlyCollection<IPrivate>)privates;

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder
                .AppendLine(base.ToString())
                .AppendLine($"Privates:");

            foreach (IPrivate pr in Privates)
                builder.AppendLine($"  {pr}");

            return builder.ToString().TrimEnd();
        }
    }
}