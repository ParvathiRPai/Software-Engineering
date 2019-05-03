using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abstraction.Tests
{
    [TestClass]
    public class FunWithMathsTests
    {
        [TestMethod]
        public void TestFunWithMathsMultiplyNumbers()
        {
            // arrange
            var op = new OddNumberProvider();
            var expected1 = 945;

            var ep = new EvenNumberProvider();
            var expected2 = 3840;

            var mp = new MockNumberProvider();
            var expected3 = 6;

            var fwm = new FunWithMaths();

            // act
            var actual1 = fwm.MultiplyNumbers(op);
            var actual2 = fwm.MultiplyNumbers(ep);
            var actual3 = fwm.MultiplyNumbers(mp);

            // assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }
    }
}
