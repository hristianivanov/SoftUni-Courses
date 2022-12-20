namespace UniversityCompetition.Models
{
    using System;

    using Contracts;
    public abstract class Subject : ISubject
    {
        private int id;
        private string name;
        private double rate;

        public Subject(int subjectId, string subjectName, double subjectRate)
        {
            Id = subjectId;
            Name = subjectName;
            Rate = subjectRate;
        }
        public int Id
        {
            get => id;
            private set => id = value;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }
        public double Rate
        {
            get => rate;
            private set => rate = value;
        }
    }
}
