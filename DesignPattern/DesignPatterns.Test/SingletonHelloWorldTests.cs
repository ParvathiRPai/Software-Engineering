using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Test
{
    [TestClass]
    public class SingletonHelloWorldTests
    {
        [TestMethod]
        public void TestSingletonHelloWorldGetInstance()
        {
            // arrange

            // act
            var instance1 = SingletonHelloWorld.GetInstance();
            var instance2 = SingletonHelloWorld.GetInstance();

            // assert
            Assert.AreEqual(instance1, instance2);
        }
    }
}
