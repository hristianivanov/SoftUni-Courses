using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models
{
    public class TechnicalSubject : Subject
    {
        private const double RATE = 1.3;
        public TechnicalSubject(int subjectId, string subjectName) 
            : base(subjectId, subjectName, RATE)
        {
        }
    }
}
