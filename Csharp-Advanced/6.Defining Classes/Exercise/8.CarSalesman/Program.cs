using System;
using System.Collections.Generic;

namespace _8.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] engineProps = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = CreateEngine(engineProps);

                engines.Add(engine);
            }
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carProps = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = CreateCar(carProps, engines);

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        public static Engine CreateEngine(string[] engineProps)
        {
            Engine engine = new Engine(engineProps[0], int.Parse(engineProps[1]));

            if (engineProps.Length > 2)
            {
                int displacement;

                bool IsDigit = int.TryParse(engineProps[2], out displacement);

                if (IsDigit)
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = engineProps[2];
                }

                if (engineProps.Length > 3)
                {
                    engine.Efficiency = engineProps[3];
                }
            }

            return engine;
        }

        public static Car CreateCar(string[] carProps, List<Engine> engines)
        {
            Engine engine = engines.Find(x => x.Model == carProps[1]);

            Car car = new Car(carProps[0], engine);

            if (carProps.Length > 2)
            {
                int weight;

                bool isDigit = int.TryParse(carProps[2], out weight);

                if (isDigit)
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = carProps[2];
                }

                if (carProps.Length > 3)
                {
                    car.Color = carProps[3];
                }
            }

            return car;
        }
    }
    
}
