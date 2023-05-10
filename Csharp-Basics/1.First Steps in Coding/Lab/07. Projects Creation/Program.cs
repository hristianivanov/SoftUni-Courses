using System;

namespace Presentation
{
    internal class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int projectsNumber = int.Parse(Console.ReadLine());
            int hoursNeeded = projectsNumber * 3;

            Console.WriteLine($"The architect {name} will need {hoursNeeded} hours to complete {projectsNumber} project/s.");
        }
    }
}
