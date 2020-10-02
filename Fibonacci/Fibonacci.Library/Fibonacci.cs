using System;

namespace Fibonacci.Library
{
    public static class Fibonacci
    {
        public const int MinDepth = 0;
        public const int MaxDepth = 10000;

        public static long Recursive( int nStartingValue)
        {
            if (nStartingValue < MinDepth || nStartingValue > MaxDepth)
                throw new ArgumentOutOfRangeException("n is out of bounds!");

            return getRecursive(nStartingValue);
        }

        private static long getRecursive(
            int n,
            long previous = 0,
            long current = 0,
            int counter = 0 )
        {     
            return counter == n ?
                current :
                getRecursive(n, current, Math.Max(previous + current, 1), counter + 1);
        }
    }
}
