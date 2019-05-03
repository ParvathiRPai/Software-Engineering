using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndOOD
{
    /// <summary>
    /// The car class, represents a Car
    /// </summary>
    public class Car
    {
        private readonly static int NumWheels = 4;

        public string Make;
        public string Model;
        public int Year;
        public List<string> OwnerHistory;

        public double Mileage { get; private set; }

        public Car()
        {
            Make = string.Empty;
            Model = string.Empty;
            Year = 0;
            Mileage = 0;
            OwnerHistory = new List<string>();
        }

        public Car(string make, string model, int year, double mileage) : this()
        {
            Make = make;
            Model = model;
            Year = year;
            Mileage = mileage;
        }

        /// <summary>
        /// Add the specified number of miles to the car
        /// </summary>
        /// <param name="milesToAdd">The number of miles to add</param>
        public void AddMiles(double milesToAdd)
        {
            if (milesToAdd < 0)
                throw new ArgumentOutOfRangeException("MilesToAdd must be >= 0");

            Mileage += milesToAdd;
        }

        public static int GetNumWheels()
        {
            return NumWheels;
        }
    }
}
