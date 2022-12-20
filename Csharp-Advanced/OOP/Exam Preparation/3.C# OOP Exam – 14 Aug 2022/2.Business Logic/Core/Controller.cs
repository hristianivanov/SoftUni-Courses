using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planetRepository;

        public Controller()
        {
            planetRepository = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            if (planetRepository.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            planetRepository.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            if (planetRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (!new string[] { "SpaceForces", "StormTroopers", "AnonymousImpactUnit" }.Contains(unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            IPlanet planet = planetRepository.FindByName(planetName);
            if (planet.Army.Any(p => p.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit military = null;
            switch (unitTypeName)
            {
                case "SpaceForces": military = new SpaceForces(); break;
                case "StormTroopers": military = new StormTroopers(); break;
                case "AnonymousImpactUnit": military = new AnonymousImpactUnit(); break;
            }
            planet.Spend(military.Cost);
            planet.AddUnit(military);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }
        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (planetRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planetRepository.FindByName(planetName);
            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            if (!new string[] { "BioChemicalWeapon", "NuclearWeapon", "SpaceMissiles" }.Contains(weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon = null;
            switch (weaponTypeName)
            {
                case "BioChemicalWeapon": weapon = new BioChemicalWeapon(destructionLevel); break;
                case "NuclearWeapon": weapon = new NuclearWeapon(destructionLevel); break;
                case "SpaceMissiles": weapon = new SpaceMissiles(destructionLevel); break;
            }
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }
        public string SpecializeForces(string planetName)
        {
            if (planetRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            IPlanet planet = planetRepository.FindByName(planetName);
            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            planet.Spend(1.25);
            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planetRepository.FindByName(planetOne);
            IPlanet secondPlanet = planetRepository.FindByName(planetTwo);
            bool IsHaveNuclearFirst = firstPlanet.Weapons.Any(w => w.GetType() == typeof(NuclearWeapon));
            bool IsHaveNuclearSecond = secondPlanet.Weapons.Any(w => w.GetType() == typeof(NuclearWeapon));

            string winningPlanetName;
            string losingPlanetName;

            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                winningPlanetName = firstPlanet.Name;
                losingPlanetName = secondPlanet.Name;
            }
            else if (secondPlanet.MilitaryPower > firstPlanet.MilitaryPower)
            {
                winningPlanetName = secondPlanet.Name;
                losingPlanetName = firstPlanet.Name;
            }
            else
            {
                if (IsHaveNuclearFirst && !IsHaveNuclearSecond)
                {
                    winningPlanetName = firstPlanet.Name;
                    losingPlanetName = secondPlanet.Name;
                }
                else if (IsHaveNuclearSecond && !IsHaveNuclearFirst)
                {
                    winningPlanetName = secondPlanet.Name;
                    losingPlanetName = firstPlanet.Name;
                }
                else
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return OutputMessages.NoWinner;
                }
            }

            IPlanet winner = planetRepository.FindByName(winningPlanetName);
            IPlanet losser = planetRepository.FindByName(losingPlanetName);

            winner.Spend(winner.Budget / 2);
            winner.Profit(losser.Budget / 2);

            winner.Profit(
                losser.Army.Sum(x => x.Cost) +
                losser.Weapons.Sum(x => x.Price)
                );

            planetRepository.RemoveItem(losser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, losser.Name);
        }
        public string ForcesReport()
        {
            var outputPlanets = planetRepository.Models.OrderByDescending(x => x.MilitaryPower)
               .ThenBy(x => x.Name);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in outputPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().Trim();
        }

    }
}