using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public List<Renovator> Renovators { get; set; }
        public int Count { get { return this.Renovators.Count; } }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (NeededRenovators <= Count)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            Renovator renovator = Renovators.FirstOrDefault(renovator => renovator.Name == name);
            return Renovators.Remove(renovator);
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> leftRenovators = Renovators.Where(x => x.Type != type).ToList();
            int count = Count - leftRenovators.Count;
            Renovators = leftRenovators;
            return count;
        }
        public Renovator HireRenovator(string name)
        {
            Renovator renovator = Renovators.FirstOrDefault(x => x.Name == name);
            if (renovator != null)
            {
                renovator.Hired = true;
            }
            return renovator;
        }
        public List<Renovator> PayRenovators(int days)
        {
            return Renovators.FindAll(x => x.Days >= days);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var item in Renovators.Where(x => !x.Hired).ToList())
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

    }
}
