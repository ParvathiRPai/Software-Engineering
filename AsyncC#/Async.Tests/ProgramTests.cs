using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Async.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestBuildStringTask()
        {
            // arrange
            var strings = new List<string> { "a", "b", "c" };
            var expected = "abc";

            // act
            var actual = Program.BuildStringTask(strings).Result;

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
