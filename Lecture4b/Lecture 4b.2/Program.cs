using System;
using System.Threading;

namespace Lecture_4b._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart loadDataStart = new ThreadStart(LoadData);

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals(""))
                {
                    Thread loadDataThread = new Thread(loadDataStart);
                    loadDataThread.Start();
                }
            }
        }

        public static void LoadData()
        {
            Console.WriteLine("Loading...");
            for (int i = 0; i < 101; i++)
            {
                Console.WriteLine($"Progress: {i}%");
                Thread.Sleep(10);
            }
        }
    }
}
