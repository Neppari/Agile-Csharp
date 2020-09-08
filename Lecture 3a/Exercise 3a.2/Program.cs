using System;

namespace Exercise_3a._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    interface IInfo
    {
        public string InfoText { get; set; }
        public void PrintInfo();
    }

    class Product : IInfo
    {
        public string InfoText { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine(InfoText);
        }
    }

    class Category : IInfo
    {
        public string InfoText { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine(InfoText);
        }
    }
}
