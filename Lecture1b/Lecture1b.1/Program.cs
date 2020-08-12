using System;
using System.Collections.Generic;

namespace Lecture2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<string> notes = new List<string>();
            int i = 0;

            //loop runs until input is "quit"
            do
            {
                input = Console.ReadLine();

                if (input == "help")
                {
                    Console.WriteLine("Available commands: \n");
                    Console.WriteLine("Command \t Function");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("help \t Displays this dialog");
                    Console.WriteLine("quit \t Closes the program");
                    Console.WriteLine("add \t Adds a new note");
                    Console.WriteLine("list \t Lists all the notes");
                    Console.WriteLine("remove \t Removes a note");
                }
                else if (input == "add")
                {
                    Console.WriteLine("Write a note:");
                    input = Console.ReadLine();
                    notes.Add(input);
                }
                else if (input == "list")
                {
                    for (int j = 0; j < notes.Count; j++)
                    {
                        Console.WriteLine(notes[j]);
                    }
                }
                else if (input == "remove")
                {
                    for (int k = 0; k < notes.Count; k++)
                    {
                        Console.WriteLine(k + "\t" + notes[k]);
                    }

                    Console.WriteLine("Which note would you like to delete?");
                    input = Console.ReadLine();
                    notes.RemoveAt(int.Parse(input));
                }

            } while (input != "quit");
        }
    }
}
