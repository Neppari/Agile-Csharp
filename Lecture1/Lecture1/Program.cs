using System;

namespace Lecture1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int luck;

            int startingHp = 5;
            int curHp;
            int enemyHp = 5;

            int enemyDmg = 1;
            int playerDmg = 1;

            Console.WriteLine("A battle begins!" + "\n");
            curHp = startingHp;

            while (curHp > 0)
            {
                Console.WriteLine("You attack the monster!");
                luck = rnd.Next(7);
                if (luck == 6)
                {
                    Console.WriteLine("The luck is: " + luck);
                    enemyHp = enemyHp - (playerDmg * 2);
                    Console.WriteLine("Monster Hp: " + enemyHp + "\n");
                }
                else if (luck < 2)
                {
                    Console.WriteLine("The luck is: " + luck);
                    Console.WriteLine("The monster avoids the attack!" + "\n");
                }
                else
                {
                    Console.WriteLine("The luck is: " + luck);
                    enemyHp = enemyHp - playerDmg;
                    Console.WriteLine("Monster Hp: " + enemyHp + "\n");
                }

                // if the enemy dies
                if (enemyHp < 1)
                {
                    Console.WriteLine("You have defeated the monster!");
                    break;
                }

                Console.WriteLine("The enemy attacks!");
                luck = rnd.Next(7);
                if (luck == 6)
                {
                    Console.WriteLine("The luck is: " + luck);
                    curHp = curHp - (enemyDmg * 2);
                    Console.WriteLine("Your Hp: " + curHp + "\n");
                }
                else if (luck < 2)
                {
                    Console.WriteLine("The luck is: " + luck);
                    Console.WriteLine("You avoid the attack!" + "\n");
                }
                else
                {
                    Console.WriteLine("The luck is: " + luck);
                    curHp = curHp - enemyDmg;
                    Console.WriteLine("Your Hp: " + curHp + "\n");
                }
            }

            if (curHp < 1)
            {
                Console.WriteLine("You have died :(");
            }

            Console.WriteLine("The battle has ended.");
        }
    }
}
