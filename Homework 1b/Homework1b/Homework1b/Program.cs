using System;
using System.Collections.Generic;

namespace Homework1b
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> list1 = new List<char>() { 'Q', 'K', 'J', 'A', 'Q', 'J', 'Q', 'J', 'J', 'K', 'Q', 'J', 'J' };
            List<char> list2 = new List<char>() { 'A', 'J', 'Q', 'J', 'K', 'Q', 'Q', 'K', 'Q', 'J', 'J', 'J', 'J' };
            List<char> list3 = new List<char>() { 'J', 'Q', 'K', 'Q', 'J', 'Q', 'J', 'J', 'A', 'J', 'J', 'K', 'Q' };

            char[] slots = new char[3];
            int playerBalance = 20;
            int bet, win;
            
            string input;
            bool inputIsValid;

            Console.WriteLine("Your current balance is " + playerBalance);

            while (playerBalance > 0)
            {
                Console.Write("Please enter your bet (1-10): ");
                input = Console.ReadLine();
                inputIsValid = int.TryParse(input, out bet);

                if (!inputIsValid)
                {
                    do
                    {
                        Console.Write("Invalid bet. Please enter a bet (1-10): ");
                        input = Console.ReadLine();
                        inputIsValid = int.TryParse(input, out bet);
                    } while(!inputIsValid);
                }

                playerBalance -= bet;

                slots[0] = RandomizeSlot(list1);
                slots[1] = RandomizeSlot(list2);
                slots[2] = RandomizeSlot(list3);

                Console.WriteLine("\n" + slots[0] + " " + slots[1] + " " + slots[2]);
                win = 0;

                if (ThreeInRow(slots, 'A'))
                {
                    win = bet * 20;
                }
                else if (ThreeInRow(slots, 'K'))
                {
                    win = bet * 8;
                }
                else if (ThreeInRow(slots, 'Q'))
                {
                    win = bet * 4;
                }
                else if (ThreeInRow(slots, 'J'))
                {
                    win = bet * 2;
                }

                playerBalance += win;
                Console.WriteLine("Last win: " + win);
                Console.WriteLine("Current balance: " + playerBalance + "\n");
            }
        }

        private static char RandomizeSlot(List<char> list)
        {
            Random rand = new Random();
            int randomListItem = rand.Next(list.Count);
            char slot = list[randomListItem];
            return slot;
        }

        private static bool ThreeInRow(char[] slots, char value)
        {
            if (slots[0] == value && slots[1] == value && slots[2] == value)
                return true;
            else
                return false;
        }
    }
}
