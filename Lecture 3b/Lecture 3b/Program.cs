using System;

namespace Lecture_3b
{
    delegate void PrintControl();

    class Program
    {
        static void Main(string[] args)
        {
            PrintControl print = delegate { };

            while (true)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "ReleaseWater":
                        print += ReleaseWater;
                        break;

                    case "ReleaseFertilizer":
                        print += ReleaseFertilizer;
                        break;

                    case "IncreaseTemperature":
                        print += IncreaseTemperature;
                        break;

                    case "run":
                        print();
                        break;

                    default:
                        Console.WriteLine("No such command.");
                        break;
                }
            }
        }

        static void ReleaseWater()
        {
            Console.WriteLine("Releasing water...");
        }

        static void ReleaseFertilizer()
        {
            Console.WriteLine("Releasing fertilizer...");
        }

        static void IncreaseTemperature()
        {
            Console.WriteLine("Increasing temperature...");
        }
    }
}
