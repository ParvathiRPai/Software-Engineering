using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestAverage()
        {
            // arrange
            var nums = new int[] { 1, 2, 3, 3 };
            var expected = 2.25;

            // act
            var actual = Program.Average(nums);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemoveFromLinkedList()
        {
            // arrange
            var list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(9);
            list.AddLast(2);
            list.AddLast(9);
            list.AddLast(3);
            var valueToRemove = 9;

            var expected = new LinkedList<int>();
            expected.AddLast(1);
            expected.AddLast(2);
            expected.AddLast(3);

            // act
            Program.RemoveFromLinkedList(list, valueToRemove);

            // assert
            CollectionAssert.AreEqual(expected, list);
        }

        [TestMethod]
        public void TestDoubleList()
        {
            // arrange
            var list = new List<int>() { 1, 2, 3 };
            var expected = new List<int>() { 2, 4, 6 };

            // act
            var actual = Program.DoubleList(list);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateUserById()
        {
            // arrange
            var user1 = new User { FirstName = "Adam", LastName = "Yoblick" };
            var user2 = new User { FirstName = "Andrea", LastName = "Enders" };
            var users = new Dictionary<int, User>();
            users[1] = user1;
            users[2] = user2;

            var expectedFirstName = "Vivian";
            var expectedLastName = "Yoblick";
            var id = 2;

            // act
            Program.UpdateUserById(users, id, expectedFirstName, expectedLastName);

            // assert
            Assert.AreEqual(expectedFirstName, user2.FirstName);
            Assert.AreEqual(expectedLastName, user2.LastName);
        }

        [TestMethod]
        public void TestRemoveFromStack()
        {
            // arrange
            var stack = new Stack<int>();
            stack.Push(3);
            stack.Push(9);
            stack.Push(2);
            stack.Push(9);
            stack.Push(1);

            var valueToRemove = 9;

            var expected = new Stack<int>();
            expected.Push(3);
            expected.Push(2);
            expected.Push(1);

            // act
            Program.RemoveFromStack(stack, valueToRemove);

            // assert
            CollectionAssert.AreEqual(expected, stack);
        }

        [TestMethod]
        public void TestGetStringFromQueue()
        {
            // arrange
            var queue = new Queue<char>();
            queue.Enqueue('a');
            queue.Enqueue('b');
            queue.Enqueue('c');

            var expectedQueue = new Queue<char>(queue);

            var numCopies = 3;

            var expected = "abcabcabc";

            // act
            var actual = Program.GetStringFromQueue(queue, numCopies);

            // assert
            Assert.AreEqual(expected, actual);
            CollectionAssert.AreEqual(expectedQueue, queue);
            
        }
    }
}
