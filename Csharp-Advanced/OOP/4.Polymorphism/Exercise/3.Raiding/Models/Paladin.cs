namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) 
            : base(name, 100)
        {

        }

        public override string CastAbility()
            => $"{GetType().Name} - {Name} healed for {Power}";
    }
}
