using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;


namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;

        protected Weapon(int destructionLevel, double price)
        {
            this.Price = price;
            this.DestructionLevel = destructionLevel;
        }

        public double Price { get; private set; }


        public int DestructionLevel
        {
            get { return destructionLevel; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                else if (value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }

                destructionLevel = value;
            }
        }


    }
}
