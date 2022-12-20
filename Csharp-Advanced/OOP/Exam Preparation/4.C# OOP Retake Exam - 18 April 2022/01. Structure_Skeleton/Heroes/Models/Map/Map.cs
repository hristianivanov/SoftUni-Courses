namespace Heroes.Models.Map
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Heroes;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = players.Where(x => x.GetType().Name == nameof(Knight))
                .ToList();
            var barbarians = players.Where(x => x.GetType().Name == nameof(Barbarian))
                .ToList();

            bool isKnightsTurn = true;
            while (knights.Any(x => x.IsAlive) && barbarians.Any(x => x.IsAlive))
            {
                if (isKnightsTurn)
                    PlayOutRound(knights, barbarians);
                else
                    PlayOutRound(barbarians, knights);

                isKnightsTurn = !isKnightsTurn;
            }

            int deathKnights = knights.Count(x => !x.IsAlive);
            int deathBarbarians = barbarians.Count(x => !x.IsAlive);

            if (knights.Any(x => x.IsAlive))
                return $"The knights took {deathKnights} casualties but won the battle.";
            else
                return $"The barbarians took {deathBarbarians} casualties but won the battle.";

        }

        private void PlayOutRound(List<IHero> atackers, List<IHero> defenders)
        {
            foreach (IHero attacker in atackers.Where(x => x.IsAlive))
                foreach (IHero defender in defenders.Where(x => x.IsAlive))
                    if (attacker.Weapon != null)
                        defender.TakeDamage(attacker.Weapon.DoDamage());
        }
    }
}
