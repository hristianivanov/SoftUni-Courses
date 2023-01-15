namespace UniversityCompetition.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Models;
    using Models.Contracts;
    using Core.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using UniversityCompetition.Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<ISubject> subjectRepository;
        private IRepository<IStudent> studentRepository;
        private IRepository<IUniversity> universityRepository;
        public Controller()
        {
            subjectRepository = new SubjectRepository();
            studentRepository = new StudentRepository();
            universityRepository = new UniversityRepository();
        }
        //public string AddSubject(string subjectName, string subjectType)
        //{
        //    int id = subjectRepository.Models.Count + 1;

        //    if (subjectRepository.FindByName(subjectName) != null)
        //        return $"{subjectName} is already added in the repository.";

        //    ISubject subject = subjectType switch
        //    {
        //        nameof(EconomicalSubject) => subject = new EconomicalSubject(id, subjectName),
        //        nameof(HumanitySubject) => subject = new HumanitySubject(id, subjectName),
        //        nameof(TechnicalSubject) => subject = new TechnicalSubject(id, subjectName),
        //        _ => null
        //    };
        //    if (subject == null)
        //        return $"Subject type {subjectType} is not available in the application!";

        //    subjectRepository.AddModel(subject);
        //    return $"{subjectType} {subjectName} is created and added to the {subjectRepository.GetType().Name}!";
        //}
        public string AddSubject(string subjectName, string subjectType)
        {
            string result = "";

            if (subjectType != nameof(TechnicalSubject) &&
                subjectType != nameof(EconomicalSubject) &&
                subjectType != nameof(HumanitySubject))
            {
                result = $"Subject type {subjectType} is not available in the application!";
            }
            else if (subjectRepository.FindByName(subjectName) != null)
            {
                result = $"{subjectName} is already added in the repository.";
            }
            else
            {
                ISubject subject;
                int subjectId = subjectRepository.Models.Count + 1;

                if (subjectType == nameof(TechnicalSubject))
                {
                    subject = new TechnicalSubject(subjectId, subjectName);
                }
                else if (subjectType == nameof(EconomicalSubject))
                {
                    subject = new EconomicalSubject(subjectId, subjectName);
                }
                else
                {
                    subject = new HumanitySubject(subjectId, subjectName);
                }

                this.subjectRepository.AddModel(subject);
                result = string
                    .Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository));
            }

            return result.TrimEnd();
        }
        public string AddStudent(string firstName, string lastName)
        {
            string result = "";

            if (this.studentRepository.FindByName($"{firstName} {lastName}") != null)
            {
                result = string.Format(OutputMessages.AlreadyAdded, $"{firstName} {lastName}");
            }
            else
            {
                IStudent student = new Student(this.studentRepository.Models.Count + 1, firstName, lastName);
                this.studentRepository.AddModel(student);
                result = string
                    .Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository));
            }

            return result.TrimEnd();
        }
        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            string result = "";

            if (this.universityRepository.FindByName(universityName) != null)
            {
                result = string.Format(OutputMessages.AlreadyAdded, universityName);
            }
            else
            {
                List<int> rs = new List<int>();
                foreach (var subName in requiredSubjects)
                {
                    rs.Add(this.subjectRepository.FindByName(subName).Id);
                }
                IUniversity university =
                    new University(this.universityRepository.Models.Count + 1, universityName, category, capacity, rs);
                this.universityRepository.AddModel(university);

                result = string
                    .Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));
            }

            return result.TrimEnd();
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string result = "";

            string firstName = studentName.Split(" ")[0];
            string lastName = studentName.Split(" ")[1];

            var student = this.studentRepository.FindByName(studentName);
            var university = this.universityRepository.FindByName(universityName);

            if (student == null)
            {
                result = string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            else if (university == null)
            {
                result = string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            else if (!university.RequiredSubjects.All(x => student.CoveredExams.Any(e => e == x)))
            {
                result = string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            else if (student.University != null && student.University.Name == universityName)
            {
                result = string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }
            else
            {
                student.JoinUniversity(university);
                result = string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
            }

            return result.TrimEnd();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            string result = "";

            if (this.studentRepository.FindById(studentId) == null)
            {
                result = string.Format(OutputMessages.InvalidStudentId);
            }
            else if (this.subjectRepository.FindById(subjectId) == null)
            {
                result = string.Format(OutputMessages.InvalidSubjectId);
            }
            else if (studentRepository.FindById(studentId).CoveredExams.Any(e => e == subjectId))
            {
                result = string
                    .Format(OutputMessages
                    .StudentAlreadyCoveredThatExam,
                    studentRepository.FindById(studentId).FirstName,
                    studentRepository.FindById(studentId).LastName,
                    subjectRepository.FindById(subjectId).Name);
            }
            else
            {
                var student = this.studentRepository.FindById(studentId);
                var subject = this.subjectRepository.FindById(subjectId);

                student.CoverExam(subject);
                result = string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
            }

            return result.TrimEnd();
        }

        public string UniversityReport(int universityId)
        {
            var university = this.universityRepository.FindById(universityId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {this.studentRepository.Models.Where(s => s.University == university).Count()}");
            sb.AppendLine($"University vacancy: {university.Capacity - this.studentRepository.Models.Where(s => s.University == university).Count()}");

            return sb.ToString().TrimEnd();
        }
    }
}