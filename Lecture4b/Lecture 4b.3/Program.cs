using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture_4b._3
{
    class Program
    {
        public static async Task LoadDataAsync()
        {
            Console.WriteLine("Loading...");
            for (int i = 0; i < 101; i++)
            {
                Console.WriteLine($"Progress: {i}%");
                await Task.Delay(10);
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals(""))
                {
                    Task task = LoadDataAsync();
                    //task.Wait(); if you want to wait for it to complete
                }
            }
        }        
    }
}
