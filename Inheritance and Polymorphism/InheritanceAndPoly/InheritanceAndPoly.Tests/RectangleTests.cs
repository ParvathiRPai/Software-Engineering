using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InheritanceAndPoly.Tests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void TestRectangle()
        {
            // arrange
            var expectedName = "Rectangle";

            // act
            var r = new Rectangle(null, 0, 0);

            // assert
            Assert.AreEqual(expectedName, r.Name);
        }

        [TestMethod]
        public void TestRectangleAreaGet()
        {
            // arrange
            var width = 5;
            var height = 5;
            var expectedArea = width * height;
            var r = new Rectangle(null, width, height);

            // act
            var actualArea = r.Area;

            // assert
            Assert.AreEqual(expectedArea, actualArea);
        }
    }
}
