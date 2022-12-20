﻿namespace Heroes.Models.Weapons
{
    using System;

    using Contracts;

    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        protected Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }

                name = value;
            }
        }
        public int Durability
        {
            get => durability;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                durability = value;
            }
        }
        public abstract int DoDamage();
    }
}
