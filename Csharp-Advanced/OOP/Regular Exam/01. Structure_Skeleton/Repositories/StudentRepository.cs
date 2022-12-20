using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private readonly List<IStudent> students;
        public StudentRepository()
        {
            students= new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models 
            => students.AsReadOnly();

        public void AddModel(IStudent student)
        {
            students.Add(student);
        }

        public IStudent FindById(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        public IStudent FindByName(string name)
        {
            var splited = name.Split(" ");
            string firstName = splited[0];
            string lastName = splited[1];
            return students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
