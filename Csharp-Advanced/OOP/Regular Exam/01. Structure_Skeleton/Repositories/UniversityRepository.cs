using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private readonly List<IUniversity> universities;
        public UniversityRepository()
        {
            universities= new List<IUniversity>();
        }
        public IReadOnlyCollection<IUniversity> Models 
            => universities.AsReadOnly();

        public void AddModel(IUniversity university)
        {
            universities.Add(university);
        }

        public IUniversity FindById(int id)
        {
            return universities.FirstOrDefault(x => x.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return universities.FirstOrDefault(x => x.Name == name);
        }
    }
}
