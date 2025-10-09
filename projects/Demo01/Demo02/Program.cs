using AnimalsDemo;
using Microsoft.CSharp.RuntimeBinder;

namespace Demo01
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            //SimpleTypeDemo();

            //var type = typeof(Snake);

            Console.Write("Which Type? ");
            string typeName = Console.ReadLine();
            var type= Type.GetType(typeName);

            //string info=ReflectionHelper.GetInfo(type);
            //Console.WriteLine(info);

            //ReflectionHelper.InvokeObjectMethods(type);

            ReflectionHelper.InvokeSpecialBehavior(type);
        }

        private static void SimpleTypeDemo()
        {
            var tiger = new Tiger();

            var t1 = tiger.GetType();

            var t2 = typeof(Tiger);

            Console.WriteLine(t1);
            Console.WriteLine(t2);

            Console.WriteLine(t1.GetHashCode());
            Console.WriteLine(t2.GetHashCode());
        }

    }
}
