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
    }
}
