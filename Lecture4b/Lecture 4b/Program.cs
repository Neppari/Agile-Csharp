using System;
using System.IO;

namespace Lecture_4b
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello!");
                Console.WriteLine("How much are you looking to save?");
                string input = Console.ReadLine();
                int saving = int.Parse(input);

                Console.WriteLine("How much is your monthly salary?");
                input = Console.ReadLine();
                int salary = int.Parse(input);

                int months = saving / salary;
                Console.WriteLine("It will take you " + months + " to save that amount.");
                Console.WriteLine("Select a folder where you want to save your result.");
                input = Console.ReadLine();

                string fileName = "\\months_until_target.txt";
                string path = @"" + input + fileName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
                switch(e.GetType().Name)
                {
                    case "FormatException":
                        Console.WriteLine("Wrong input format.");
                        break;
                    case "DivideByZeroException":
                        Console.WriteLine("You will never reach your goal");
                        break;
                    case "DirectoryNotFoundException":
                        Console.WriteLine("Invalid path.");
                        break;
                    default:
                        Console.WriteLine("An error occurred.");
                        break;
                }
            }

        }
    }
}
