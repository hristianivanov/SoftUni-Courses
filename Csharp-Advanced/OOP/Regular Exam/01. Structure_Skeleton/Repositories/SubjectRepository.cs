
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private readonly List<ISubject> subjects;
        public SubjectRepository()
        {
            subjects = new List<ISubject>();
        }
        public IReadOnlyCollection<ISubject> Models 
            => subjects.AsReadOnly();

        public void AddModel(ISubject subject)
        {
            subjects.Add(subject);
        }

        public ISubject FindById(int id)
        {
            return  subjects.FirstOrDefault(x=>x.Id== id);
        }

        public ISubject FindByName(string name)
        {
            return subjects.FirstOrDefault(x => x.Name == name);
        }
    }
}
