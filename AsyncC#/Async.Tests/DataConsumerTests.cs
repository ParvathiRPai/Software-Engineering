using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Async.Tests
{
    [TestClass]
    public class DataConsumerTests
    {
        [TestMethod]
        public void TestSum()
        {
            // arrange
            var consumer = new DataConsumer();
            var mockProvider = new Mock<IDataProvider>(MockBehavior.Strict);
            var nums = new List<int>() { 1, 2, 3 };
            mockProvider
                .Setup(x => x.GetDataAsync())
                .Returns(Task.FromResult(nums));
            var expected = 6;

            // act
            var actual = consumer.Sum(mockProvider.Object);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
