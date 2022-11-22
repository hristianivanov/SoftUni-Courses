using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
                string pizzaName = Console.ReadLine().Split()[1];

                string[] doughInput = Console.ReadLine().Split();
                string flour = doughInput[1];
                string baking = doughInput[2];
                double grams = double.Parse(doughInput[3]);
            try
            {
                Dough dough = new Dough(flour, baking, grams);
                Pizza pizza = new Pizza(pizzaName, dough);

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string topType = input.Split()[1];
                    double topGrams = double.Parse(input.Split()[2]);

                    Topping topping = new Topping(topType, topGrams);

                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        }
    }
}
