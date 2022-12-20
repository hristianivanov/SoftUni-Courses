namespace Gym.Models.Athletes
{
    using System;
    public class Boxer : Athlete
    {
        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, 60)
        {
        }

        public override void Exercise()
        {
            if (Stamina + 15 > 100)
            {
                Stamina = 100;
                throw new ArgumentException("Stamina cannot exceed 100 points.");
            }
            Stamina += 15;
        }
    }
}
