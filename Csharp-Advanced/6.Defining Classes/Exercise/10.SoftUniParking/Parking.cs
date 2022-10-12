using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count { get { return this.cars.Count; } }

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber==car.RegistrationNumber))
                return "Car with that registration number, already exists!";
            if (cars.Count + 1 > capacity)
                return "Parking is full!";
            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public Car GetCar(string regNum) => cars.SingleOrDefault(cars => cars.RegistrationNumber == regNum);
        public string RemoveCar(string regNum)
        {
            if (cars.Any(x => x.RegistrationNumber == regNum))
            {
                cars.Remove(GetCar(regNum));
                return $"Successfully removed {regNum}";
            }
            return "Car with that registration number, doesn't exist!";
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                this.RemoveCar(registrationNumber);
            }
        }

    }
}