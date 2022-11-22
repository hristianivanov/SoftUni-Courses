using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private string material;
        private int capacity;
        private List<Fish> fish;
        public Net(string material, int capacity)
        {
            Fish = new List<Fish>();
            Material = material;
            Capacity = capacity;
        }


        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public List<Fish> Fish
        {
            get { return fish; }
            set { fish = value; }
        }
        public int Count { get { return this.Fish.Count; } }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) || fish.Weight<=0 || fish.Length<=0)
            {
                return "Invalid fish.";
            }
            if (this.Fish.Count+1> Capacity)
            {
                return "Fishing net is full.";
            }
            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish fish = this.Fish.FirstOrDefault(x => x.Weight == weight);
            return this.Fish.Remove(fish);
        }

        public Fish GetFish(string fishType)
        {
            return Fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return Fish.OrderByDescending(x=>x.Length).First();
        }

        public string Report()
        {
            this.Fish = this.Fish.OrderByDescending(x => x.Length).ToList();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Into the {Material}:");
            fish.ForEach(fish => stringBuilder.AppendLine(fish.ToString()));
            return stringBuilder.ToString().Trim();
        }
    }
}
