namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
            : base(name, 80)
        {

        }

        public override string CastAbility()
            => $"{GetType().Name} - {Name} hit for {Power} damage";
    }
}
