namespace Heroes.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Models.Map;
    using Models.Contracts;
    using Models.Heroes;
    using Models.Weapons;

    internal class Controller : IController
    {
        private IRepository<IWeapon> weapons;
        private IRepository<IHero> heroes;
        public Controller()
        {
            weapons = new WeaponRepository();
            heroes = new HeroRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (heroes.FindByName(heroName) == null)
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            if (weapons.FindByName(weaponName) == null)
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");

            IHero hero = heroes.FindByName(heroName);
            if (hero.Weapon != null)
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");

            IWeapon weapon = weapons.FindByName(weaponName);
            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name) != null)
                throw new InvalidOperationException($"The hero {name} already exists.");

            IHero hero = type switch
            {
                nameof(Knight) => new Knight(name, health, armour),
                nameof(Barbarian) => new Barbarian(name, health, armour),
                _ => throw new InvalidOperationException("Invalid hero type.")
            };

            heroes.Add(hero);
            if (type == nameof(Knight))
                return $"Successfully added Sir {name} to the collection.";
            else
                return $"Successfully added Barbarian {name} to the collection.";
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
                throw new InvalidOperationException($"The weapon {name} already exists.");
            IWeapon weapon = type switch
            {
                nameof(Claymore) => weapon = new Claymore(name, durability),
                nameof(Mace) => weapon = new Mace(name, durability),
                _ => throw new InvalidOperationException("Invalid weapon type.")
            };
            weapons.Add(weapon);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }
        public string HeroReport()
        {
            var orderedHeroes = heroes.Models.OrderBy(x => x.GetType().Name)
                 .ThenByDescending(x => x.Health)
                 .ThenBy(x => x.Name);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var hero in orderedHeroes)
            {
                string weaponName = hero.Weapon != null ? hero.Weapon.Name : "Unarmed";
                stringBuilder.AppendLine($"{hero.GetType().Name}: {hero.Name}")
                         .AppendLine($"--Health: {hero.Health}")
                         .AppendLine($"--Armour: {hero.Armour}")
                         .AppendLine($"--Weapon: {weaponName}");
            }

            return stringBuilder.ToString().Trim();
        }
        public string StartBattle()
        {
            Map map = new Map();
            var battleHeroes = heroes.Models
                            .Where(x => x.IsAlive && x.Weapon != null)
                            .ToList();

            return map.Fight(battleHeroes);
        }
    }
}