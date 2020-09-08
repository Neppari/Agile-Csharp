using System;
using System.Globalization;

namespace Lecture2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 40;
            bool prime;

            for (int i = 2; i <= max; i++)
            {
                prime = true;

                for (int j = 0; j < i; j++)
                {
                    for (int k = j; k < i; k++)
                    {
                        if (j * k == i)
                        {
                            prime = false;
                        }
                    }
                }

                if (prime)
                {
                    Console.WriteLine(i.ToString() + " is a prime number.");
                }
            }
        }
    }
}
