﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsDemo
{
    public abstract class Bird : Animal
    {
        public override string Breed()
        {
            return "Egg Laying";
        }

        public override string Move()
        {
            return Fly();
        }

        public string Fly()
        {
            return "Fly is sky";
        }
    }


    public class Parrot: Bird
    {
        public override string Eat()
        {
            return "Eats Fruits";
        }
    }

    public class Eagle : Bird, IHunter
    {
        public override string Eat()
        {
            return "Flesh Eater";
        }

       
        public string Hunt()
        {
            return "Flying Hunters";
        }
    }

}
