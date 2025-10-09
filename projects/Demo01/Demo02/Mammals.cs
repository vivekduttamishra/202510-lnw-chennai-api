using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsDemo
{
    public abstract class Mammal : Animal
    {
        public override string Breed()
        {
            return "Child Birth";
        }
        public override string Move()
        {
            return "Moves on Land";
        }
    }

    public class Cat : Mammal, IHunter
    {
        public override string Eat()
        {
            return "Eats Flesh";
        }

        public virtual string Hunt()
        {
            return "Hunts its prey";
        }
       
    }


    class Tiger : Cat { }
    class Leopard : Cat { }

    public class Horse : Mammal
    {
        public override string Eat()
        {
            return "Grass Eater";
        }
        [SpecialBehavior]
        public string Ride()
        {
            return "Great Ride";
        }
    }

    public class Camel : Mammal
    {
        public override string Eat()
        {
            return "Grass Eater";
        }

        [SpecialBehavior]
        public string Ride()
        {
            return "Desert Ride";
        }
    }

    public class Cow : Mammal
    {
        public override string Eat()
        {
            return "Grass Eater";
        }
        [SpecialBehavior]
        public string ProvidesMilk()
        {
            return "Milk Provider";
        }
    }
}
