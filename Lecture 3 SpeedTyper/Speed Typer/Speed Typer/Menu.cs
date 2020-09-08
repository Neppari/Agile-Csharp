using System;
using System.Collections.Generic;
using System.Text;

namespace Speed_Typer
{
    class Menu
    {
        public void StartMenu()
        {
            Console.WriteLine("Welcome to word blitz!");
            Console.WriteLine("Select the game mode:\n");
            Console.WriteLine("1. Score Run");
            Console.WriteLine("2. Infinite mode");
            Console.WriteLine("3. help");
            Console.WriteLine("4. quit");
        }

        public void Help()
        {
            Console.WriteLine("In Score Run, you type words as fast as possible. You can define how many words you want to type.\n");
            Console.Write("In Infinite mode, we will calculate how many words you type per minute.\n");
        }

        public void ScoreRunEnd(int words, double score)
        {
            Console.WriteLine("Well done! Your final score is " + score);
            Console.WriteLine("You typed " + words + " words\n");
        }

        public void ScoreRunStart()
        {
            Console.WriteLine("How many words would you like to type?");
        }

        public void Misspelled(string word)
        {
            Console.WriteLine($"Misspelled! Write \"{word}\" again.");
        }

        public void InvalidCommand()
        {
            Console.WriteLine("The command you wrote is invalid. Try again.");
        }
    }
}
