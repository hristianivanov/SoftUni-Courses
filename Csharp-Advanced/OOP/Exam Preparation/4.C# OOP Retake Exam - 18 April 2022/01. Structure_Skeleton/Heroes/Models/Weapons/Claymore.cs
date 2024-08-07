﻿namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        public Claymore(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (Durability == 0)
                return 0;
            Durability--;
            return 20;
        }
    }
}
