namespace BirthdayCelebrations.Models.Interfaces
{
    using System;
    public interface IBirthdatable
    {
        public string Birthdate { get; }

        public void SearchBirthdateYear(string year);
    }
}
