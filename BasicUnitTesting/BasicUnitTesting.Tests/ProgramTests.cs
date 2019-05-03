using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicUnitTesting.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestSumArray()
        {
            // arrange
            var array = new int[4] { 1, 2, 3, 4 };
            var expected = 10;

            // act
            var actual = Program.SumArray(array);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSumArrayNullArray()
        {
            // arrange
            int[] array = null;
            var expected = 0;

            // act
            var actual = Program.SumArray(array);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSumArrayEmptyArray()
        {
            // arrange
            var array = new int[0];
            var expected = 0;

            // act
            var actual = Program.SumArray(array);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetValueAtIndex()
        {
            // arrange
            var array = new int[5] { 1, 2, 3, 4, 5 };
            var index = 2;
            var expected = 3;

            // act
            var actual = Program.GetValueAtIndex(array, index);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetValueAtIndexNullArray()
        {
            // arrange
            int[] array = null;
            var index = 2;

            // act
            Program.GetValueAtIndex(array, index);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestGetValueAtIndexIndexTooLow()
        {
            // arrange
            var array = new int[5] { 1, 2, 3, 4, 5 };
            var index = -1;

            // act
            Program.GetValueAtIndex(array, index);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestGetValueAtIndexIndexTooHigh()
        {
            // arrange
            var array = new int[5] { 1, 2, 3, 4, 5 };
            var index = 10;

            // act
            Program.GetValueAtIndex(array, index);
        }
    }
}
