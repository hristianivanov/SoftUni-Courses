using System;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) 
            : base(name, 100)
        {

        }

        public override string CastAbility()
            => $"{GetType().Name} - {Name} hit for {Power} damage";
    }
}
