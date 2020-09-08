using System;

namespace Lecture1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! What day is it?");

            string input = Console.ReadLine();
            int daysRemaining = 0;

            switch (input)
            {
                case "monday":
                    daysRemaining = 7;
                    break;

                case "tuesday":
                    daysRemaining = 6;
                    break;

                case "wednesday":
                    daysRemaining = 5;
                    break;

                case "thursday":
                    daysRemaining = 4;
                    break;

                case "friday":
                    daysRemaining = 3;
                    break;

                case "saturday":
                    daysRemaining = 2;
                    break;

                case "sunday":
                    daysRemaining = 1;
                    break;

                default:
                    Console.WriteLine("Did you misspell?");
                    break;
            }

            if (daysRemaining > 3)
            {
                Console.WriteLine("Have a nice week!");
            }
            else if (daysRemaining == 0)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine("Have a nice weekend!");
            }
        }
    }
}
