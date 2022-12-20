namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        public Mace(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (Durability == 0)
                return 0;
            Durability--;
            return 25;
        }
    }
}
