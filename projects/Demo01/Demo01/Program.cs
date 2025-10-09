using AnimalsDemo;
using Microsoft.CSharp.RuntimeBinder;

namespace Demo01
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Animal[] animals =
                        {
                            
                            new Tiger(),
                            new Crocodile(),
                            new Horse(),
                            new Cow(),
                            new Parrot(),
                            new Eagle(),
                            new Snake(),
                            new Camel()
                        };


            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.Eat());
                Console.WriteLine(animal.Move());
                Console.WriteLine(animal.Breed());
                HuntIfYouCan(animal);
                Console.WriteLine("\n\n");
            }


        }

        private static void HuntIfYouCan(object anything)
        {
            //does this object have hunt?
            var huntMethod = anything.GetType().GetMethod("Hunt");
            if (huntMethod != null && huntMethod.GetParameters().Length==0)
            {
                var result = huntMethod.Invoke(anything, null);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine($"{anything.GetType().Name} does't Hunt");
            }

        }

        private static void HuntIfYouCan2(dynamic animal)
        {
            try
            {
                Console.WriteLine(animal.Hunt());
            }catch(RuntimeBinderException ex)
            {
                Console.WriteLine(animal + " Is not a Hunter");
            }
            
        }

        private static void HuntIfYouCan1(Animal animal)
        {
            if(animal is IHunter)
            {
                var hunter = (IHunter) animal;
                Console.WriteLine(hunter.Hunt());
            }
        }
    }
}
