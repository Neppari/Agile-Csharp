using System;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your year of birth:");

            int curYear = DateTime.Now.Year;
            string input = Console.ReadLine();
            bool inputIsValid = false, ageIsValid = false;
            int inputYear, age = 0;

            do
            {
                //input is valid, if it can be converted into an int
                inputIsValid = int.TryParse(input, out inputYear);

                if (!inputIsValid)
                {
                    Console.WriteLine("Invalid input. Please enter your year of birth:");
                    input = Console.ReadLine();
                }
                else
                {
                    //calculate age and check if it's valid
                    age = curYear - inputYear;
                    if (age < 125 && age > 0)
                    {
                        ageIsValid = true;
                    }
                    else
                    {
                        ageIsValid = false;
                        Console.WriteLine("Something's fishy here.. Please enter your year of birth again:");
                        input = Console.ReadLine();
                    }
                }
            } while (!inputIsValid || !ageIsValid);

            Console.WriteLine("Your age is " + age);

            if (age < 18)
            {
                Console.WriteLine("You are not old enough to use this application.");
            }
            else
            {
                Console.WriteLine("Please answer this verification question correctly:");
                Console.WriteLine("What was done to the VHS cassette after finishing a movie?");
                Console.WriteLine("1. The cassette was blown into.");
                Console.WriteLine("2. The cassette was flipped to reveal the rest of the content.");
                Console.WriteLine("3. The cassette was rewinded to begin at the start.");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Nice try, kiddo..");
                        break;
                    case "2":
                        Console.WriteLine("Welcome to the application!");
                        break;
                    case "3":
                        Console.WriteLine("Nice try, kiddo..");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }
    }
}
