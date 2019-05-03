using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassesAndOOD.Tests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void TestCarConstructor()
        {
            // arrange
            var expectedMake = string.Empty;
            var expectedModel = string.Empty;
            var expectedYear = 0;
            var expectedMileage = 0;

            // act
            var actualCar = new Car();

            // assert
            Assert.AreEqual(expectedMake, actualCar.Make);
            Assert.AreEqual(expectedModel, actualCar.Model);
            Assert.AreEqual(expectedYear, actualCar.Year);
            Assert.AreEqual(expectedMileage, actualCar.Mileage);
            Assert.IsNotNull(actualCar.OwnerHistory);
        }

        [TestMethod]
        public void TestCarConstructorMakeModelYearMileage()
        {
            // arrange
            var expectedMake = "Tesla";
            var expectedModel = "Model S";
            var expectedYear = 2018;
            var expectedMileage = 17;

            // act
            var actualCar = new Car(expectedMake, expectedModel, expectedYear, expectedMileage);

            // assert
            Assert.AreEqual(expectedMake, actualCar.Make);
            Assert.AreEqual(expectedModel, actualCar.Model);
            Assert.AreEqual(expectedYear, actualCar.Year);
            Assert.AreEqual(expectedMileage, actualCar.Mileage);
            Assert.IsNotNull(actualCar.OwnerHistory);
        }

        [TestMethod]
        public void TestCarAddMiles()
        {
            // arrange
            var car = new Car();
            var milesToAdd = 5;
            var expectedMileage = 5;

            // act
            car.AddMiles(milesToAdd);

            // assert
            Assert.AreEqual(expectedMileage, car.Mileage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCarAddMilesInvalidMilesToAdd()
        {
            // arrange
            var car = new Car();
            var milesToAdd = -200;

            // act
            car.AddMiles(milesToAdd);
        }

        [TestMethod]
        public void TestCarGetNumWheels()
        {
            // arrange
            var expected = 4;

            // act
            var actual = Car.GetNumWheels();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
