using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Test
{
    [TestClass]
    public class CommandManagerTests
    {
        [TestMethod]
        public void TestCommandManager()
        {
            // arrange
            var cm = new CommandManager();
            var command = new AddCommand(0, 1);
            var expected = 3;

            // act
            cm.Execute(command);
            cm.Redo();
            cm.Redo();
            cm.Redo();
            cm.Redo();
            cm.Undo();
            cm.Undo();

            // assert
            Assert.AreEqual(expected, cm.CurrentValue);
        }
    }
}
