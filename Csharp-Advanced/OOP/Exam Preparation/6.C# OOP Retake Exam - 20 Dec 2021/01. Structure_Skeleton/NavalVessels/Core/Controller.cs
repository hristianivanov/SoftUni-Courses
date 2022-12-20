namespace NavalVessels.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models;
    using Models.Contracts;
    using Repositories;
    using Repositories.Contracts;

    public class Controller : IController
    {
        private IRepository<IVessel> vesselRepository;
        private List<ICaptain> captains;
        public Controller()
        {
            vesselRepository = new VesselRepository();
            captains = new List<ICaptain>();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            IVessel vessel = vesselRepository.FindByName(selectedVesselName);
            if (captain == null)
                return $"Captain {selectedCaptainName} could not be found.";
            if (vessel == null)
                return $"Vessel {selectedVesselName} could not be found.";
            if (vessel.Captain != null)
                return $"Vessel {selectedVesselName} is already occupied.";

            vessel.Captain = captain;
            captain.AddVessel(vessel);
            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }
        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = vesselRepository.FindByName(attackingVesselName);
            IVessel defender = vesselRepository.FindByName(defendingVesselName);

            if (attacker == null)
                return $"Vessel {attackingVesselName} could not be found.";
            if (defender == null)
                return $"Vessel {defendingVesselName} could not be found.";

            if (attacker.ArmorThickness == 0)
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            if (defender.ArmorThickness == 0)
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defender.ArmorThickness}.";
        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vesselRepository.FindByName(name) != null)
                return $"{vesselType} vessel {name} is already manufactured.";
            IVessel vessel = vesselType switch
            {
                nameof(Submarine) => vessel = new Submarine(name, mainWeaponCaliber, speed),
                nameof(Battleship) => vessel = new Battleship(name, mainWeaponCaliber, speed),
                _ => null
            };
            if (vessel == null)
                return "Invalid vessel type.";

            vesselRepository.Add(vessel);
            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }
        public string HireCaptain(string fullName)
        {
            if (captains.Any(x => x.FullName == fullName))
                return $"Captain {fullName} is already hired.";

            ICaptain captain = new Captain(fullName);
            captains.Add(captain);
            return $"Captain {fullName} is hired.";
        }
        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vesselRepository.FindByName(vesselName);
            if (vesselRepository.FindByName(vesselName) == null)
                return $"Vessel {vesselName} could not be found.";

            vessel.RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }
        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vesselRepository.FindByName(vesselName);
            if (vesselRepository.FindByName(vesselName) == null)
                return $"Vessel {vesselName} could not be found.";
            if (vessel is Battleship battleship)
            {
                battleship.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            if (vessel is Submarine submarine)
            {
                submarine.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
            throw new InvalidOperationException("Not suported vessel type");
        }
        public string CaptainReport(string captainFullName)
            => captains.Single(x => x.FullName == captainFullName).Report();
        public string VesselReport(string vesselName)
            => vesselRepository.FindByName(vesselName).ToString();
    }
}