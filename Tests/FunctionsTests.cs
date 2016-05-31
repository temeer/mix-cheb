using NUnit.Framework;
using static mixhaar.Functions.Function;

namespace Tests
{
    [TestFixture]
    public class FunctionsTests
    {
        [Test]
        public void MixedHaar2Test()
        {
            var y = MixedHaar2(2, 3)(1);
            Assert.AreEqual(0.5,y);
        }

        [Test]
        public void FactorialTest()
        {
            Assert.AreEqual(1, Factorial(0));
            Assert.AreEqual(1, Factorial(1));
            Assert.AreEqual(2, Factorial(2));
            Assert.AreEqual(6, Factorial(3));
            Assert.AreEqual(3628800, Factorial(10));
        }
    }
}