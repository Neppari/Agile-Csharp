using System;

namespace meri_mattila_interviewdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            long maxFor10 = 9999999999;
            long a;
            long firstPrime10;

            for (long i = 1000000000; i <= maxFor10; i++)
            {
                a = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        a++;
                    }
                }

                if (a == 2)
                {
                    Console.WriteLine(i + "is the first prime number with 10 digits");
                    firstPrime10 = i;
                    break;
                }
            }

            long maxFor11 = 99999999999;
            long firstPrime11;

            for (long k = 10000000000; k <= maxFor11; k++)
            {
                a = 0;
                for (int l = 1; l <= k; l++)
                {
                    if (k % l == 0)
                    {
                        a++;
                    }
                }

                if (a == 2)
                {
                    Console.WriteLine(k + "is the first prime number with 11 digits");
                    firstPrime11 = k;
                    break;
                }
            }
        }
    }
}
