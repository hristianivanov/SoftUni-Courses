namespace Stealer
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Reflection;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            FieldInfo[] fields = classType.GetFields((BindingFlags)60);
            object classInstance = Activator.CreateInstance(classType);

            sb.AppendLine($"Class under investigation: {className}");
            foreach (FieldInfo field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in nonPublicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
