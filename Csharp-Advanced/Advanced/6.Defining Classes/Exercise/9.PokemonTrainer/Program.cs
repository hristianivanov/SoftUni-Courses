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
            string lines = string.Empty;
            Dictionary<string, Trainer> kvp = new Dictionary<string, Trainer>();
            while ((lines = Console.ReadLine()) != "Tournament")
            {
                string[] splitted = lines.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                GetData(kvp, splitted);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "Fire":
                    case "Water":
                    case "Electricity":
                        kvp = AddBadgeOrDamage(kvp, command);
                        break;
                }

            }

            foreach (var item in kvp.Values.OrderByDescending(t => t.BadgeCnt))
            {
                Console.WriteLine($"{item.Name} {item.BadgeCnt} {item.Pokemons.Count}");
            }
        }

        private static void GetData(Dictionary<string, Trainer> kvp, string[] splitted)
        {
            string trainerName = splitted[0];
            string pokemonName = splitted[1];
            string pokemonElement = splitted[2];
            int pokemonHealth = int.Parse(splitted[3]);
            Pokemon pokemon = new Pokemon() { Name = pokemonName, Element = pokemonElement, Health = pokemonHealth };
            if (kvp.ContainsKey(trainerName))
            {
                kvp[trainerName].Pokemons.Add(pokemon);
            }
            else
            {
                Trainer trainer = new Trainer(trainerName,pokemon);
                kvp.Add(trainerName, trainer);
            }
        }

        private static Dictionary<string, Trainer> AddBadgeOrDamage(Dictionary<string, Trainer> kvp, string command)
        {
            foreach (var item in kvp.Values)
            {
                if (item.Pokemons.Any(p => p.Element == command))
                {
                    item.BadgeCnt++;
                    continue;
                }
                else
                {
                    item.Pokemons.ForEach(pokemon => pokemon.Health -= 10);
                    if (item.Pokemons.Any(pokemon => pokemon.Health <= 0))
                    {
                        item.Pokemons = item.Pokemons.Where(pokemon => pokemon.Health > 0).ToList();
                    }
                }
            }
            return kvp;
        }
    }
}
