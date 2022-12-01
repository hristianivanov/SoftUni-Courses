namespace Raiding.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using Exceptions;
    using Interfaces;
    using IO.Interfaces;
    using Models;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<IBaseHero> entities;

        private Engine()
        {
            entities = new HashSet<IBaseHero>();
        }

        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int count = int.Parse(reader.ReadLine());
            while (entities.Count < count)
            {
                string name = reader.ReadLine();
                string heroType = reader.ReadLine();
                try
                {
                    IBaseHero hero;
                    if (heroType == "Druid")
                        hero = new Druid(name);
                    else if (heroType == "Paladin")
                        hero = new Paladin(name);
                    else if (heroType == "Rogue")
                        hero = new Rogue(name);
                    else if (heroType == "Warrior")
                        hero = new Warrior(name);
                    else
                        throw new InvalidHeroTypeException(ExceptionMessages.InvalidHeroTypeExceptionMessage);

                    entities.Add(hero);
                }
                catch (InvalidHeroTypeException ihte)
                {
                    writer.WriteLine(ihte.Message);
                }
            }

            int bossHealth = int.Parse(reader.ReadLine());
            int damage = entities.Sum(e => e.Power);

            foreach (IBaseHero hero in entities)
            {
                writer.WriteLine(hero.CastAbility());
            }

            if (bossHealth > damage)
                writer.WriteLine("Defeat...");
            else
                writer.WriteLine("Victory!");
        }
    }
}
