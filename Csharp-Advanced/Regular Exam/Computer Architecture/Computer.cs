using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private string model;
        private int capacity;
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public List<CPU> Multiprocessor
        {
            get { return multiprocessor; }
            set { multiprocessor = value; }
        }
        public int Count { get { return this.Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count+1<=Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            CPU cPU = Multiprocessor.FirstOrDefault(c => c.Brand == brand);
            if (cPU != null)
            {
                Multiprocessor.Remove(cPU);
                return true;
            }
            return false;
        }
        public CPU MostPowerful()
        {
            return Multiprocessor.OrderByDescending(x => x.Frequency).FirstOrDefault();
        }
        public CPU GetCPU(string brand)
        {
            CPU cPU = Multiprocessor.FirstOrDefault(c => c.Brand == brand);
            if (cPU != null)
                return cPU;
            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            Multiprocessor.ForEach(cPU => sb.AppendLine(cPU.ToString()));

            return sb.ToString().Trim();
        }
    }
}
