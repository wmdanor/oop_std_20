﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public abstract class RepkaHandler
    {
        private RepkaHandler _successor;
        public RepkaHandler SetSuccessor(RepkaHandler successor)
        {
            _successor = successor;
            return successor;
        }

        public virtual string Handle(string stage)
        {
            if (_successor != null)
            {
                return _successor.Handle(stage);
            }
            else
            {
                return null;
            }
        }
    }

    public class GrandfatherHandler : RepkaHandler
    {
        public override string Handle(string stage)
        {
            if (stage == "Grandfather")
            {
                return "Repka is stronger than grandfather.";
            }
            else
            {
                return base.Handle(stage);
            }
        }
    }

    public class GrandmotherHandler : RepkaHandler
    {
        public override string Handle(string stage)
        {
            if (stage == "Grandmother")
            {
                return "Repka is stronger than grandfather and grandmother taken together.";
            }
            else
            {
                return base.Handle(stage);
            }
        }
    }

    public class GranddaughterHandler : RepkaHandler
    {
        public override string Handle(string stage)
        {
            if (stage == "Granddaughter")
            {
                return "Repka is stronger than grandfather, grandmother and granddaughter taken together.";
            }
            else
            {
                return base.Handle(stage);
            }
        }
    }

    public class DogHandler : RepkaHandler
    {
        public override string Handle(string stage)
        {
            if (stage == "Dog")
            {
                return "Repka is stronger than grandfather, grandmother, granddaughter and dog taken together.";
            }
            else
            {
                return base.Handle(stage);
            }
        }
    }

    public class CatHandler : RepkaHandler
    {
        public override string Handle(string stage)
        {
            if (stage == "Cat")
            {
                return "Repka is stronger than grandfather, grandmother, granddaughter, dog and cat taken together.";
            }
            else
            {
                return base.Handle(stage);
            }
        }
    }

    public class MouseHandler : RepkaHandler
    {
        public override string Handle(string stage)
        {
            if (stage == "Mouse")
            {
                return "Repka is defeated by the joint efforts of grandfather, grandmother, granddaughter, dog, cat and mouse.";
            }
            else
            {
                return base.Handle(stage);
            }
        }
    }

    public class Character
    {
        public string Name { get; set; }
        public int Power { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var grandfather = new GrandfatherHandler();
            var grandmother = new GrandmotherHandler();
            var granddaughter = new GranddaughterHandler();
            var dog = new DogHandler();
            var cat = new CatHandler();
            var mouse = new MouseHandler();

            grandfather.SetSuccessor(grandmother).SetSuccessor(granddaughter).SetSuccessor(dog).SetSuccessor(cat).SetSuccessor(mouse);

            Console.WriteLine(grandfather.Handle("Grandfather"));
            Console.WriteLine(grandfather.Handle("Grandmother"));
            Console.WriteLine(grandfather.Handle("Granddaughter"));
            Console.WriteLine(grandfather.Handle("Dog"));
            Console.WriteLine(grandfather.Handle("Cat"));
            Console.WriteLine(grandfather.Handle("Mouse"));

            Console.ReadKey();
        }
    }
}
