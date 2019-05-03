using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InheritanceAndPoly.Tests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void TestCircle()
        {
            // arrange
            var expectedName = "Circle";
            var expectedPoint = new Point(1, 2);
            var expectedRadius = 1;

            // act
            var c = new Circle(expectedPoint, expectedRadius);

            // assert
            Assert.AreEqual(expectedName, c.Name);
            Assert.AreEqual(expectedPoint, c.Center);
            Assert.AreEqual(expectedRadius, c.Radius);
        }

        [TestMethod]
        public void TestCircleConstructors()
        {
            // arrange
            int r = 5;
            float r2 = 5;
            double r3 = 5;
            var expectedRadius = 5;
            var expectedPoint = new Point(7, 45);
            var expectedPoint2 = new Point(0, 0);

            // act
            var c1 = new Circle(expectedPoint, r);
            var c2 = new Circle(expectedPoint, r2);
            var c3 = new Circle(r3);

            // assert
            Assert.AreEqual(expectedRadius, c1.Radius);
            Assert.AreEqual(expectedPoint, c1.Center);

            Assert.AreEqual(expectedRadius, c2.Radius);
            Assert.AreEqual(expectedPoint, c2.Center);

            Assert.AreEqual(expectedRadius, c3.Radius);
            Assert.AreEqual(expectedPoint2, c3.Center);
        }

        [TestMethod]
        public void TestCircleAreaGet()
        {
            // arrange
            var expectedRadius = 5;
            var expectedArea = Math.PI * expectedRadius * expectedRadius;
            var c = new Circle(null, expectedRadius);

            // act
            var actualArea = c.Area;

            // assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod]
        public void TestCircleEquals()
        {
            // arrange
            var c1 = new Circle(new Point(1, 1), 1);
            var c2 = new Circle(new Point(1, 1), 1);
            var c3 = new Circle(new Point(2, 2), 23894723);

            Assert.AreEqual(c1, c2);
            Assert.AreNotEqual(c2, c3);
        }
    }
}
