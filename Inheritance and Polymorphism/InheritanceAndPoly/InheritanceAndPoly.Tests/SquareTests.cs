using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InheritanceAndPoly.Tests
{
    [TestClass]
    public class SquareTests
    {
        [TestMethod]
        public void TestSquare()
        {
            // arrange
            var expectedName = "Square";

            // act
            var s = new Square(null, 0);

            // assert
            Assert.AreEqual(expectedName, s.Name);
        }

        [TestMethod]
        public void TestSquareAreaGet()
        {
            // arrange
            var width = 10;
            var expectedArea = width * width;
            var s = new Square(null, width);

            // act
            var actualArea = s.Area;

            // assert
            Assert.AreEqual(expectedArea, actualArea);
        }
    }
}
