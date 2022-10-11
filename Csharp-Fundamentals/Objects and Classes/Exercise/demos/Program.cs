using System;
using System.Text;

namespace demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            // "Type: {typeOfVehicle}
            //  Model: { modelOfVehicle}
            //  Color: { colorOfVehicle}
            //  Horsepower: { horsepowerOfVehicle}"

            stringBuilder.AppendLine("Type: {typeOfVehicle}");
            stringBuilder.AppendLine("Model: {modelOfVehicle}");
            stringBuilder.AppendLine("Color: {colorOfVehicle}");
            stringBuilder.Append("Horsepower: {horsepowerOfVehicle}");

            Console.WriteLine(stringBuilder);



        }
    }
}
