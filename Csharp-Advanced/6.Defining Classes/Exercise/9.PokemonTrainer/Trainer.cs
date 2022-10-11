using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            BadgeCnt = 0;
            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int BadgeCnt { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void AddBadge(string element)
        {
            if (Pokemons.Any(pokemon=>pokemon.Element==element))
            {
                BadgeCnt++;
            }
        }
        public void Damage()
        {
            if (Pokemons.Any(pokemon=>pokemon.Health<=0))
            {
                Pokemons.Where(pokemon=>pokemon.Health<=0);
            }
            Pokemons.ForEach(pokemon => pokemon.Health -= 10);

        }
    }
}
