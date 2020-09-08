using System;
using System.Collections.Generic;

namespace Speed_Typer
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Gameplay gameplay = new Gameplay();

            int roundsToPlay = 0;
            double scoreRunScore = 0;
            string input;

            while(true)
            {
                menu.StartMenu();

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        menu.ScoreRunStart();
                        roundsToPlay = int.Parse(Console.ReadLine());
                        for (int i = 0; i < roundsToPlay; i++)
                        {
                            scoreRunScore = gameplay.ScoreRunLoop();
                        }
                        menu.ScoreRunEnd(roundsToPlay, scoreRunScore);
                        break;

                    case "2":
                        gameplay.InfiniteModeLoop();
                        break;

                    case "3":
                        menu.Help();
                        break;

                    case "4":
                        return;

                    default:
                        menu.InvalidCommand();
                        break;
                }
            }
        }
    }
}
