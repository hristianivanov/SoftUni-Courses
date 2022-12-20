namespace Gym.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Repositories;
    using Models.Athletes;
    using Models.Athletes.Contracts;
    using Models.Equipment;
    using Models.Equipment.Contracts;
    using Models.Gyms;
    using Models.Gyms.Contracts;

    public class Controller : IController
    {
        private List<IGym> gyms;
        private EquipmentRepository equipmentRepository;
        public Controller()
        {
            this.gyms = new List<IGym>();
            this.equipmentRepository = new EquipmentRepository();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = gymType switch
            {
                nameof(BoxingGym) => gym = new BoxingGym(gymName),
                nameof(WeightliftingGym) => new WeightliftingGym(gymName),
                _ => null
            };
            if (gym == null)
                throw new InvalidOperationException("Invalid gym type.");

            this.gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }
        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = equipmentType switch
            {
                nameof(BoxingGloves) => equipment = new BoxingGloves(),
                nameof(Kettlebell) => equipment = new Kettlebell(),
                _ => null
            };
            if (equipment == null)
                throw new InvalidOperationException("Invalid equipment type.");

            this.equipmentRepository.Add(equipment);
            return $"Successfully added {equipmentType}.";
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (equipmentRepository.FindByType(equipmentType) == null)
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            IEquipment equipment = equipmentRepository.FindByType(equipmentType);
            IGym gym = gyms.First(x => x.Name == gymName);
            gym.AddEquipment(equipment);
            equipmentRepository.Remove(equipment);

            return $"Successfully added {equipmentType} to {gymName}.";
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = athleteType switch
            {
                nameof(Boxer) => athlete = new Boxer(athleteName, motivation, numberOfMedals),
                nameof(Weightlifter) => athlete = new Weightlifter(athleteName, motivation, numberOfMedals),
                _ => null
            };
            if (athlete == null)
                throw new InvalidOperationException("Invalid athlete type.");

            IGym gym = gyms.First(x => x.Name == gymName);
            var gymType = gym.GetType().Name;
            if (gymType == nameof(BoxingGym))
            {
                if (athlete is Weightlifter)
                    return "The gym is not appropriate.";
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                if (athlete is Boxer)
                    return "The gym is not appropriate.";
            }

            gym.AddAthlete(athlete);
            return $"Successfully added {athleteType} to {gymName}.";
        }
        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.First(x => x.Name == gymName);
            gym.Exercise();
            var athletesCount = gym.Athletes.Count;
            return $"Exercise athletes: {athletesCount}.";
        }
        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.First(x => x.Name == gymName);
            var value = gym.EquipmentWeight;
            return $"The total weight of the equipment in the gym {gymName} is {value:f2} grams.";
        }
        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var gym in gyms)
                stringBuilder.AppendLine(gym.GymInfo());

            return stringBuilder.ToString().Trim();
        }
    }
}