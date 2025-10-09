
using AnimalsDemo;
using System.Reflection;
using System.Text;

namespace Demo01
{
    internal class ReflectionHelper
    {
        internal static string GetInfo(Type type)
        {
            var info= new StringBuilder();

            info.AppendLine($"namespace {type.Namespace}");
            info.AppendLine("{");
            info.Append("\t");
            if (type.IsPublic)
                info.Append("public ");

            if (type.IsEnum)
                info.Append("enum ");
            else if (type.IsInterface)
                info.Append("interface ");
            else if (type.IsValueType)
                info.Append("struct ");
            else
            {
                if (type.IsAbstract)
                    info.Append("abstract ");
                info.Append("class ");
            }
            
            info.AppendLine($"{type.Name}");
            info.AppendLine("\t{");

            info.AppendLine("\t\t//properties");
            foreach (var property in type.GetProperties())
                info.AppendLine($"\t\t{property}");
            info.AppendLine();
            info.AppendLine("\t\t//methods");
            foreach (var method in type.GetMethods())
                info.AppendLine($"\t\t{method}");
            info.AppendLine();
            info.AppendLine("\t\t//fields");
            foreach (var field in type.GetFields(BindingFlags.NonPublic|BindingFlags.Instance) )
                info.AppendLine($"\t\t{field}");


            info.AppendLine("\t}");
            info.AppendLine("}");
            return info.ToString();
        }
    
        public static void InvokeObjectMethods(Type t)
        {
           var obj= Activator.CreateInstance(t);
           InvokeObjectMethods(obj);
        }

        public static void InvokeObjectMethods(object instance)
        {
            var type = instance.GetType();

            foreach(var method in type.GetMethods())
            {
                if (method.DeclaringType == typeof(object))
                    continue; //ignore them
                if(method.GetParameters().Length == 0)
                {
                    Console.Write($"Trying to Invoke: {method.Name}... ");
                    var result = method.Invoke(instance, null); //same as instance.method()
                    Console.WriteLine(result);
                    Console.WriteLine();
                }
            }
        }



        public static void InvokeSpecialBehavior(Type t)
        {
            var obj = Activator.CreateInstance(t);
            InvokeSpecialBehavior(obj);
        }

        public static void InvokeSpecialBehavior(object instance)
        {
            var type = instance.GetType();
            int specialBehaviorCount = 0;
            foreach (var method in type.GetMethods())
            {
                if (method.DeclaringType == typeof(object))
                    continue; //ignore them
                if (method.GetParameters().Length == 0)
                {
                    //check for special behavior attribute
                    var specialBehavior = method.GetCustomAttribute<SpecialBehaviorAttribute>();
                    if (specialBehavior == null)
                        continue;

                    specialBehaviorCount++;
                    Console.Write($"Trying to Invoke: {method.Name}... ");
                    var result = method.Invoke(instance, null); //same as instance.method()
                    Console.WriteLine(result);
                    Console.WriteLine();
                }
                
            }
            if (specialBehaviorCount == 0)
            {
                Console.WriteLine($"{type.Name} has no special behavior");
            }
        }

    }
}