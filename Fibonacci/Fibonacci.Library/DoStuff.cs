using System;
using System.Collections.Generic;
using System.Text;

namespace Fibonacci.Library
{
    public static class DoStuff
    {
        public static long DoX(int nStartingValue)
        {
            if (nStartingValue < 0 || nStartingValue > 150)
                throw new ArgumentOutOfRangeException("n is out of bounds!");

            long doY(int n) => n > 0 ? n * doY(n - 1) : 1;

            return doY(nStartingValue);
        }
    }
}
