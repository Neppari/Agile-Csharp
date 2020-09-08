using System;
using System.Collections.Generic;

namespace Lecture2a
{
    class Program
    {
        static void Main(string[] args)
        {
            void Sum(int val1, int val2)
            {
                Console.WriteLine("The sum of " + val1 + " and " + val2 + " is " + (val1 + val2));
            }

            void Difference(int val1, int val2)
            {
                Console.WriteLine("The difference of " + val1 + " and " + val2 + " is " + (val1 - val2));
            }

            Sum(2, 5);
            Sum(20, 3);
            Difference(5, 2);
            Difference(2, 100);

            void RemoveSpaces(string text)
            {
                int spaces = 0;

                foreach(char c in text)
                {
                    if(c == ' ')
                    {
                        spaces++;
                    }
                }
                Console.WriteLine(spaces);
                Console.WriteLine(text.Replace(" ", ""));
            }

            void UniqueLetters(string text)
            {
                string checkedChars = "";

                foreach(char c in text)
                {
                    if(!checkedChars.Contains(c))
                    {
                        checkedChars += c;
                        Console.WriteLine(c);
                    }
                }
            }

            string input = Console.ReadLine();
            UniqueLetters(input);
            RemoveSpaces(input);
        }
    }
}
