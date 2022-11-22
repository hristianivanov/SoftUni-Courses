using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name,Pokemon pokemon)
        {
            Name = name;
            BadgeCnt = 0;
            Pokemons = new List<Pokemon>();
            Pokemons.Add(pokemon);
        }
        public string Name { get; set; }
        public int BadgeCnt { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
