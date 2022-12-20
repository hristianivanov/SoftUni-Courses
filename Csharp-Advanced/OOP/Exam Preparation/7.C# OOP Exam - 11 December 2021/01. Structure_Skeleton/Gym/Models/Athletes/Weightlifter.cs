using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, 50)
        {
        }

        public override void Exercise()
        {
            if (Stamina + 10 > 100)
            {
                Stamina = 100;
                throw new ArgumentException("Stamina cannot exceed 100 points.");
            }
            Stamina += 10;
        }
    }
}
