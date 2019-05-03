using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaaS.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestGetTopOldestUsers()
        {
            // arrange
            var numUsers = 10;
            var numTopUsers = 3;
            var mockProvider = new Mock<IDataProvider>(MockBehavior.Strict);
            mockProvider.Setup(x => x.GetUsers()).Returns(GetMockUsers(numUsers));

            // act
            var users = Program.GetTopOldestUsers(mockProvider.Object, numTopUsers).ToList();

            // assert

            // make sure there are users
            Assert.IsNotNull(users);

            // make sure the number of users is correct
            Assert.AreEqual(numTopUsers, users.Count);

            // GetMockUsers returns N users, and each user's SSN represents the user number
            // Since each user is one day younger than the previous one, the top N oldest users should have the lowest ssn values
            for (int i = 0; i < numTopUsers; i++)
            {
                Assert.AreEqual(i, users[i].Ssn);
            }
        }

        /// <summary>
        /// Helper method to get a list of mock users, in random order
        /// </summary>
        /// <param name="count">The number of users to generate</param>
        /// <returns>The users</returns>
        private IEnumerable<User> GetMockUsers(int count)
        {
            var users = new List<User>();

            // generate a list of users
            // each user is younger than the previous by one day
            for (var i=0; i<count; i++)
            {
                var user = new User
                {
                    FirstName = "FirstName" + i,
                    LastName = "LastName" + i,
                    Ssn = i,
                    BirthDate = DateTime.MinValue.AddDays(i)
                };
                users.Add(user);
            }

            Shuffle(users);
            return users;
        }

        /// <summary>
        /// Helper method to shuffls a list, in place
        /// Copied from https://stackoverflow.com/questions/273313/randomize-a-listt
        /// </summary>
        /// <param name="list">The list</param>
        private void Shuffle(IList<User> list)
        {
            Random rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
