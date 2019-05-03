using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaaS
{
    /// <summary>
    /// The SqlDataProvider class, provides data from Sql
    /// </summary>
    public class SqlDataProvider : IDataProvider
    {
        // events used for hooks
        private event EventHandler OnGetUsersStarted;
        private event EventHandler OnGetUsersFinished;

        // subscribe to the OnGetUsersStarted event
        public void OnGetUsersStartedSubscribe(EventHandler handler)
        {
            OnGetUsersStarted += handler;
        }

        // subscribe to the OnGetUsersFinishedEvent
        public void OnGetUsersFinishedSubscribe(EventHandler handler)
        {
            OnGetUsersFinished += handler;
        }

        /// <summary>
        /// Get the users
        /// </summary>
        /// <returns>The users</returns>
        public IEnumerable<User> GetUsers()
        {
            // notify all event subscribers
            OnGetUsersStarted?.Invoke(this, null);

            // imagine this method gets users from sql

            // we will fake some execution time to simulate the query
            // get a random number between 0 and 5000, using the current time as a seed
            var random = new Random(DateTime.Now.Millisecond);
            var waitTime = random.Next(5000);

            // wait this number of milliseconds
            Thread.Sleep(waitTime);

            // return some users, the data doesn't matter for the purposes of this exercise
            var numUsers = random.Next(20);
            var users = new List<User>();
            for(var i = 0; i<numUsers; i++)
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

            // notify all event subscribers
            OnGetUsersFinished?.Invoke(this, null);

            return users;
        }
    }
}
