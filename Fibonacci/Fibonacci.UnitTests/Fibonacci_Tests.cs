using NUnit.Framework;
using System;
using FibonacciLib = Fibonacci.Library.Fibonacci;
using DoStuffLib = Fibonacci.Library.DoStuff;

namespace Fibonacci.UnitTests
{
    [TestFixture]
    public class Fibonacci_Tests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        public void Recursive_Always_ShouldReturnNthFibonacci(int n, long expected)
            => Assert.AreEqual(expected, FibonacciLib.Recursive(n));


        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        public void Recursive_WhenIsOutOfBounds_ShouldThrowArgumentOutOfRange(int n)
            => Assert.Throws<ArgumentOutOfRangeException>(() => FibonacciLib.Recursive(n));

        //DoX
        [TestCase(1)]
        [TestCase(int.MaxValue)]
        [TestCase(27)]
        [TestCase(-1)]
        public void DoX_Test_Thing(int n)
            => Assert.Throws<ArgumentOutOfRangeException>(() => DoStuffLib.DoX(n));
    }
}