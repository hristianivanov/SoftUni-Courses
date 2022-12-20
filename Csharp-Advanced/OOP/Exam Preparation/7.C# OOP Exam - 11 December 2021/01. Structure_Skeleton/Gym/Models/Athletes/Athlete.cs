namespace Gym.Models.Athletes
{
    using System;

    using Contracts;
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;
        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Athlete name cannot be null or empty.");
                fullName = value;
            }
        }
        public string Motivation
        {
            get => motivation;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("The motivation cannot be null or empty.");
                motivation = value;
            }
        }
        public int Stamina { get; protected set; }
        public int NumberOfMedals
        {
            get => numberOfMedals;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Athlete's number of medals cannot be below 0.");
                numberOfMedals = value;
            }
        }
        public abstract void Exercise();
    }
}
