using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InheritanceAndPoly.Tests
{
    [TestClass]
    public class ShapeTests
    {
        [TestMethod]
        public void TestShapeToString()
        {
            // arrange
            var expectedName = "Square";

            // act
            var s = new Square(null, 0);

            // assert
            Assert.AreEqual(expectedName, s.ToString());
        }
    }
}
