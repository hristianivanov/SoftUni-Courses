namespace NavalVessels.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    public class Captain : ICaptain
    {
        private string fullName;
        private List<IVessel> vessels;
        public Captain(string fullName)
        {
            this.FullName = fullName;
            CombatExperience = 0;
            vessels = new List<IVessel>();
        }
        public ICollection<IVessel> Vessels
            => vessels.AsReadOnly();
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }
                fullName = value;
            }
        }
        public int CombatExperience { get; private set; }
        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            vessels.Add(vessel);
        }
        public void IncreaseCombatExperience()
            => CombatExperience += 10;
        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");
            if (vessels.Count > 0)
            {
                foreach (var vessel in vessels)
                {
                    stringBuilder.AppendLine(vessel.ToString());
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
