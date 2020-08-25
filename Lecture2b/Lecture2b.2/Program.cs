using System;

namespace Lecture2b._2
{
    class Animal
    {
        private string name;
        private string sound;

        public Animal(string animalName, string animalSound)
        {
            name = animalName;
            sound = animalSound;
        }

        public void Greet()
        {
            Console.WriteLine(name + " says " + sound + "!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal cat = new Animal("Pinja", "meow");
            cat.Greet();

            Animal dog = new Animal("Muffe", "boof");
            dog.Greet();
        }
    }
}
