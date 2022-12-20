using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjectRepository;
        private StudentRepository studentRepository;
        private UniversityRepository universityRepository;
        public Controller()
        {
            subjectRepository = new SubjectRepository();
            studentRepository = new StudentRepository();
            universityRepository = new UniversityRepository();
        }
        public string AddSubject(string subjectName, string subjectType)
        {
            int id = subjectRepository.Models.Count + 1;

            if (subjectRepository.FindByName(subjectName) != null)
                return $"{subjectName} is already added in the repository.";

            ISubject subject = subjectType switch
            {
                nameof(EconomicalSubject) => subject = new EconomicalSubject(id, subjectName),
                nameof(HumanitySubject) => subject = new HumanitySubject(id, subjectName),
                nameof(TechnicalSubject) => subject = new TechnicalSubject(id, subjectName),
                _ => null
            };
            if (subject == null)
                return $"Subject type {subjectType} is not available in the application!";

            subjectRepository.AddModel(subject);
            return $"{subjectType} {subjectName} is created and added to the {subjectRepository.GetType().Name}!";
        }
        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universityRepository.FindByName(universityName) != null)
                return $"{universityName} is already added in the repository.";

            int id = universityRepository.Models.Count + 1;
            var subjectsId = new List<int>();
            foreach (var subject in requiredSubjects)
            {
                subjectsId.Add(subjectRepository.FindByName(subject).Id);
            }
            IUniversity university = new University(id, universityName, category, capacity, subjectsId);
            universityRepository.AddModel(university);
            return $"{universityName} university is created and added to the {universityRepository.GetType().Name}!";
        }
        public string AddStudent(string firstName, string lastName)
        {
            int id = studentRepository.Models.Count + 1;
            string name = firstName + " " + lastName;
            if (studentRepository.FindByName(name) != null)
                return $"{firstName} {lastName} is already added in the repository.";

            IStudent student = new Student(id, firstName, lastName);
            studentRepository.AddModel(student);
            return $"Student {firstName} {lastName} is added to the StudentRepository!";
        }
        public string ApplyToUniversity(string studentName, string universityName)
        {
            var splited = studentName.Split(" ");
            string studentFirstName = splited[0];
            string studentLastName = splited[1];

            IStudent student = studentRepository.FindByName(studentName);
            IUniversity university = universityRepository.FindByName(universityName);
            if (student == null)
                return $"{studentFirstName} {studentLastName} is not registered in the application!";
            if (university == null)
                return $"{universityName} is not registered in the application!";

            if (student.University == university)
                return $"{studentFirstName} {studentLastName} has already joined {university.Name}.";
            foreach (var subject in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(subject))
                {
                    return $"{studentName} has not covered all the required exams for {universityName} university!";
                }
            }

            student.JoinUniversity(university);
            return $"{studentFirstName} {studentLastName} joined {universityName} university!";
        }
        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = studentRepository.FindById(studentId);
            ISubject subject = subjectRepository.FindById(subjectId);
            if (studentRepository.FindById(studentId) == null)
                return "Invalid student ID!";
            if (subjectRepository.FindById(subjectId) == null)
                return "Invalid subject ID!";

            if (student.CoveredExams != null && student.CoveredExams.Contains(subjectId))
                return $"{student.FirstName} {student.LastName} has already covered exam of {subject.Name}.";

            student.CoverExam(subject);
            return $"{student.FirstName} {student.LastName} covered {subject.Name} exam!";
        }
        public string UniversityReport(int universityId)
        {
            IUniversity university = universityRepository.FindById(universityId);

            var studentsCount = studentRepository.Models.Count(x => x.University == university);
            var capacityLeft = university.Capacity - studentsCount;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"*** {university.Name} ***")
                         .AppendLine($"Profile: {university.Category}")
                         .AppendLine($"Students admitted: {studentsCount}")
                         .AppendLine($"University vacancy: {capacityLeft}");

            return stringBuilder.ToString().Trim();
        }
    }
}