using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Test
{
    [TestClass]
    public class AddCommandTests
    {
        [TestMethod]
        public void TestAddCommand()
        {
            // arrange
            var originalValue = 5;
            var numberToAdd = 5;
            var expected = originalValue + numberToAdd;

            var command = new AddCommand(originalValue, numberToAdd);

            // act & assert
            command.Execute();
            Assert.AreEqual(expected, command.CurrentValue);

            // act & assert
            command.Undo();
            Assert.AreEqual(originalValue, command.CurrentValue);
        }
    }
}
