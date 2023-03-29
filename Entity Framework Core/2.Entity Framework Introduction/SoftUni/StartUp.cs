using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            Console.WriteLine(RemoveTown(context));
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var e in employees)
                stringBuilder.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");

            return stringBuilder.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new { e.FirstName, e.Salary })
                .Where(e => e.Salary > 50000)
                .ToArray();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var e in employees)
                stringBuilder.AppendLine($"{e.FirstName} - {e.Salary:f2}");

            return stringBuilder.ToString().TrimEnd();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new { e.FirstName, e.LastName, DepartmentName = e.Department.Name, e.Salary })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");

            return sb.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee? employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee!.Address = address;

            context.SaveChanges();

            var employeeAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address!.AddressText)
                .ToArray();

            return string.Join(Environment.NewLine, employeeAddresses);
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager!.LastName,
                    Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue ?
                            ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    })
                    .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town!.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => $"{a.AddressText}, {a.Town!.Name} - {a.Employees.Count} employees")
                .ToArray();

            return string.Join(Environment.NewLine, addresses);
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(p => new { p.Project.Name }).OrderBy(p => p.Name).ToArray()
                })
                .FirstOrDefault();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            sb.AppendLine(string.Join(Environment.NewLine, employee.Projects.Select(x => x.Name)));

            return sb.ToString().TrimEnd();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName}  {d.ManagerLastName}");
                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    Startdate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .ToArray();


            return string.Join(Environment.NewLine, projects.Select(x => x.Name + Environment.NewLine + x.Description + Environment.NewLine + x.Startdate));
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departmentNames = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(e => departmentNames.Contains(e.Department.Name))
                .ToArray();

            foreach (var e in employees)
                e.Salary *= 1.12m;

            string[] employeesInfo = employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:f2})")
                .ToArray();

            return string.Join(Environment.NewLine, employeesInfo);
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            return string.Join(Environment.NewLine, employees.Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})"));
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeesProjectsToDelete = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(employeesProjectsToDelete);

            var projectToDelete = context.Projects.Where(p => p.ProjectId == 2);
            context.Projects.RemoveRange(projectToDelete);

            context.SaveChanges();

            string[] projectsNames = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            return string.Join(Environment.NewLine, projectsNames);
        }
        public static string RemoveTown(SoftUniContext context)
        {
            Town? townToDelete = context.Towns
                .Where(t => t.Name == "Seattle")
                .FirstOrDefault();

            Address[] addressesToDelete = context.Addresses
                .Where(a => a.TownId == townToDelete!.TownId)
                .ToArray();

            Employee[] employeesToRemoveAddressFrom = context.Employees
               .Where(e => addressesToDelete.Contains(e.Address))
               .ToArray();

            foreach (Employee e in employeesToRemoveAddressFrom)
                e.AddressId = null;

            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.Remove(townToDelete!);

            context.SaveChanges();

            return $"{addressesToDelete.Count()} addresses in Seattle were deleted";
        }
    }
}