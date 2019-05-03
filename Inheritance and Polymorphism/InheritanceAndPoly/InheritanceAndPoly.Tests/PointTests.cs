using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InheritanceAndPoly.Tests
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void TestPointEquals()
        {
            // arrange
            var p1 = new Point(1, 5);
            var p2 = new Point(1, 5);
            var p3 = new Point(6, 6);

            // assert
            Assert.AreEqual(p1, p2);
            Assert.AreNotEqual(p2, p3);
        }
    }
}
