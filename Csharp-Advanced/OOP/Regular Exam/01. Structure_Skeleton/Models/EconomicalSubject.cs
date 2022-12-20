using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models
{
    public class EconomicalSubject : Subject
    {
        private const double RATE = 1.0;
        public EconomicalSubject(int subjectId, string subjectName) 
            : base(subjectId, subjectName, RATE)
        {
        }
    }
}
