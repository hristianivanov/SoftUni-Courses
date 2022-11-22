using System;
using System.Collections.Generic;
using System.Text;

namespace _7.RawData
{
    public class Car
    {
        public Car(string model,Engine engine,Cargo cargo,Tyre[] tyres)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tyres = tyres;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tyre[] Tyres { get; set; }
    }
}

