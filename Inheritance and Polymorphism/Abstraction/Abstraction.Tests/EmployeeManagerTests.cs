using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abstraction.Tests
{
    [TestClass]
    public class EmployeeManagerTests
    {
        [TestMethod]
        public void TestEmployeeManagerGetTotalSalary()
        {
            // arrange
            var employees = new Employee[] { new WorkerBee("Adam"), new Boss("William") };
            var em = new EmployeeManager();
            var expected = 1000001;

            // act
            var actual = em.GetTotalSalary(employees);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
