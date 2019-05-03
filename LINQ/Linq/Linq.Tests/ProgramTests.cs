using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Linq.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestProgramIncrement()
        {
            // arrange
            var list = new List<int>() { 1, 2, 3 };
            var expected = new List<int>() { 2, 3, 4 };

            // act
            var actual = Program.Increment(list);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestProgramGetWhereDivisibleBy()
        {
            // arrange
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var divisor = 2;
            var expected = new int[] { 2, 4 };

            // act
            var actual = Program.GetWhereDivisibleBy(list, divisor);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestProgramAnyCapitals()
        {
            // arrange
            var s = "Hello World!";
            var s2 = s.ToLower();

            // act
            var actual = Program.AnyCapitals(s);
            var actual2 = Program.AnyCapitals(s2);

            // assert
            Assert.IsTrue(actual);
            Assert.IsFalse(actual2);
        }

        [TestMethod]
        public void TestProgramGetLastOddElement()
        {
            // arrange
            var nums = new int[] { 2, 4, 6, 8 };
            var nums2 = new int[] { 1, 2, 3, 4, 5, 6 };

            // act
            var actual = Program.GetLastOddElement(nums);
            var actual2 = Program.GetLastOddElement(nums2);

            // assert
            Assert.AreEqual(0, actual);
            Assert.AreEqual(5, actual2);
        }

        [TestMethod]
        public void TestProgramGetMinListListValue()
        {
            // arrange
            var lists = new List<List<int>>();
            lists.Add(new List<int>() { 9, 8, 7 });
            lists.Add(new List<int>() { 6, 5, 4 });
            lists.Add(new List<int>() { 1, 2, 3 });

            // act
            var min = Program.GetMinListListValue(lists);

            // assert
            Assert.AreEqual(1, min);
        }

        [TestMethod]
        public void TestProgramSortUsersByAge()
        {
            // arrange
            var users = new List<User>();
            users.Add(new User() { Age = 25, LastName = "G" });
            users.Add(new User() { Age = 57, LastName = "Z" });
            users.Add(new User() { Age = 57, LastName = "F" });

            // act
            var actual = Program.SortUsersByAge(users);

            // assert
            Assert.AreEqual(57, actual[0].Age);
            Assert.AreEqual("F", actual[0].LastName);

            Assert.AreEqual(57, actual[1].Age);
            Assert.AreEqual("Z", actual[1].LastName);

            Assert.AreEqual(25, actual[2].Age);
        }
    }
}
