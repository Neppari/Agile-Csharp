using System;

namespace Lecture1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a note:");
            string input = Console.ReadLine();

            if (input.Length < 30)
            {
                Console.WriteLine(DateTime.Now.ToString() + "\t" + input);
            }
            else
            {
                Console.WriteLine(DateTime.Now.ToString() + "\n" + input);
            }
        }
    }
}
