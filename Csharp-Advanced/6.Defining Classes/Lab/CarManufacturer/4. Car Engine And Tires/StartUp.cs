﻿using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            var tires = new Tire[4]
            {
                new Tire(1,2.5),
                new Tire(1,2.1),
                new Tire(2,0.5),
                new Tire(2,2.3)
            };

            var engine = new Engine(560, 6300);

            var car = new Car("Lamborghini", "Urus", 2010, 250, 8, engine, tires);
        }
    }
}
