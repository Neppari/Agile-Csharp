using System;
using System.Collections.Generic;

namespace Lecture_4c
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = GetPopulatedList<int>(3, 4);
            List<string> list2 = GetPopulatedList<string>("Ya hoo~!", 5);

            foreach (string value in list2)
                Console.WriteLine(value);
        }

        static List<T> GetPopulatedList<T>(T value, int length)
        {
            List<T> newList = new List<T>();

            for (int i = 0; i < length; i++)
            {
                newList.Add(value);
            }

            return newList;
        }
    }
}
