using System;
using System.Collections.Generic;
using System.Text;

namespace Speed_Typer
{
    class Gameplay
    {
        List<string> words = new List<string>()
        { "dog", "cat", "kitten", "puppy" };

        static string input, wordToType;
        static DateTime startTime, endTime;
        static double elapsedTime, playerScore;

        Random rand = new Random();
        Menu menu = new Menu();

        public double ScoreRunLoop()
        {
            wordToType = words[rand.Next(words.Count)];
            Console.WriteLine(wordToType);
            startTime = DateTime.Now;

            do
            {
                input = Console.ReadLine();

                if (!wordToType.Equals(input))
                {
                    menu.Misspelled(wordToType);
                }
            } while (!wordToType.Equals(input));

            endTime = DateTime.Now;
            elapsedTime = (endTime - startTime).TotalMilliseconds;
            playerScore += elapsedTime * wordToType.Length;
            Console.WriteLine($"Your score is {playerScore}\n");
            return playerScore;
        }

        #region Infinite Mode
        public void InfiniteModeLoop()
        {
            startTime = DateTime.Now;
            endTime = DateTime.Now.AddSeconds(60);
            DateTime timeNow;
            int wordsTyped = 0;

            do
            {
                timeNow = DateTime.Now;
                wordToType = words[rand.Next(words.Count)];
                Console.WriteLine(wordToType);

                do {
                input = Console.ReadLine();

                    if (!wordToType.Equals(input))
                    {
                        menu.Misspelled(wordToType);
                    }
                } while (!wordToType.Equals(input));

                wordsTyped++;

            } while (timeNow < endTime);

            Console.WriteLine("Words typed in the last minute: " + wordsTyped);
        }
        #endregion

    }
}
