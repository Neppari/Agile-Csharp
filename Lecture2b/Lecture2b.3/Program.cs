using System;
using System.Collections.Generic;

namespace Lecture2b._3
{
    abstract class Animal
    {
        string name, sound;

        public Animal(string aName, string aSound)
        {
            name = aName;
            sound = aSound;
        }

        public void Greet()
        {
            Console.WriteLine($"{name} says {sound}!");
        }
    }

    class Dog: Animal
    {
        public Dog(string dName, string dSound): base(dName, dSound) { }

        public void Howl()
        {
            Console.WriteLine("Howling..");
        }
    }

    class Cat: Animal
    {
        public Cat(string cName, string cSound) : base(cName, cSound) { }

        public int lives = 9;
    }

    class Pig: Animal
    {
        public Pig(string pName, string pSound) : base(pName, pSound) { }

        public bool wantsMoreFood = true;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> allAnimals = new List<Animal>();

            Dog dog1 = new Dog("Muffe", "Boof");
            Dog dog2 = new Dog("Rekku", "Woof");
            Cat cat1 = new Cat("Pinja", "Meow");
            Pig pig1 = new Pig("Tryffeli", "...");

            allAnimals.Add(dog1);
            allAnimals.Add(dog2);
            allAnimals.Add(cat1);
            allAnimals.Add(pig1);

            for (int i = 0; i < allAnimals.Count; i++)
            {
                allAnimals[i].Greet();
            }
        }
    }
}
