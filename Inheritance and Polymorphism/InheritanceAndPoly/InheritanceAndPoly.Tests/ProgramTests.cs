using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InheritanceAndPoly.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestGetShapeArea()
        {
            // arrange
            var c = new Circle(3);
            var expectedArea1 = c.Area;

            var r = new Rectangle(null, 4, 5);
            var expectedArea2 = r.Area;

            var s = new Square(null, 6);
            var expectedArea3 = s.Area;

            // act
            var actualArea1 = Program.GetShapeArea(c);
            var actualArea2 = Program.GetShapeArea(r);
            var actualArea3 = Program.GetShapeArea(s);

            // assert
            Assert.AreEqual(expectedArea1, actualArea1);
            Assert.AreEqual(expectedArea2, actualArea2);
            Assert.AreEqual(expectedArea3, actualArea3);
        }
    }
}
