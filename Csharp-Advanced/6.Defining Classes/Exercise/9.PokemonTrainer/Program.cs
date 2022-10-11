using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace _9.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
            string lines = string.Empty;

            List<Trainer> trainers = new List<Trainer>();
            while ((lines = Console.ReadLine()) != "Tournament")
            {
                string[] splitted = lines.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = splitted[0];

                trainers.Add(GetData(splitted));

            }
            string command = string.Empty;
            while ((command=Console.ReadLine())!="End")
            {
                switch (command)
                {
                    case "Fire":
                    case "Water":
                    case "Electricity":
                       bool check =  trainers.Any(trainer => trainer.Pokemons.Any(pokemon=>pokemon.Element==command));
                        if (check)
                        {
                            trainers.ForEach(trainer => trainer.AddBadge(command));
                        }
                        else
                        {
                            trainers.ForEach(trainer => trainer.Damage());
                        }
                        break;
                }

            }
            foreach (var trainer in trainers.OrderByDescending(t=>t.BadgeCnt))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgeCnt} {trainer.Pokemons.Count}");
            }

        }
        public static Trainer GetData(string[] splitted)
        {
            string trainerName = splitted[0];
            string pokemonName = splitted[1];
            string pokemonElement = splitted[2];
            int pokemonHealth = int.Parse(splitted[3]);

            Trainer trainer = new Trainer(trainerName);
            Pokemon pokemon = new Pokemon() { Name = pokemonName, Element = pokemonElement, Health = pokemonHealth };
            trainer.Pokemons.Add(pokemon);
            return trainer;
        }
    }
}
