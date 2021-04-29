using NUnit.Framework;

namespace Interviews.Tests
{
    [TestFixture()]
    public class FibonacciTests
    {
        [TestCase( 1, 0 )]
        [TestCase( 2, 1 )]
        [TestCase( 3, 1 )]
        [TestCase( 13, 144 )]
        [TestCase( 93, 7540113804746346429 )]
        public void CalculateNthNumber(int nth, long result)
        {
            Assert.AreEqual( result, Fibonacci.NthNumber( nth ) );
        }

        [Test]
        public void OverflowTest()
        {
            long a = 4660046610375530000;
            long b = 7540113804746350000;
            long result = a + b;
            Assert.IsTrue( result < 0 );
        }
    }
}
