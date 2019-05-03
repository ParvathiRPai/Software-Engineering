using System;
using System.Collections.Generic;
using System.Linq;
using Logger;

namespace SaaS
{
    delegate void HookDelegate();

    public class Program
    {
        public static void Main(string[] args)
        {
            var metricProvider = SqlMetricProvider.GetInstance();
        }

        /// <summary>
        /// Get the top N oldest users
        /// This method has logic errors in it on purpose, your task is to debug it using the provided Log
        /// class to simulate working on a service, DO NOT USE BREAKPOINTS
        /// </summary>
        /// <param name="dataProvider">The data provider</param>
        /// <param name="num">The number of users to get</param>
        /// <returns>The users</returns>
        public static IEnumerable<User> GetTopOldestUsers(IDataProvider dataProvider, int num)
        {
            var log = Log.GetInstance(@"C:\Users\v-papai\Downloads\LeapStudy\OneDrive_1_8-20-2018\test.txt");
            log.WriteLine("entering function gettop oldest users");
            // get the users
            var users = dataProvider.GetUsers();
            foreach(var user in users)
            {
                log.WriteLine(Log.Level.Detailed, Log.EventType.Info, user.BirthDate.ToString());
            }

            // sort the users by birthdate
            users = users.OrderByDescending(x => x.BirthDate);

            // get the top number
            users = users.Skip(num);
            log.WriteLine("exit function gettop oldest users");
            // return the results
            return users.ToList();
        }

        public static IEnumerable<User> GetTopOldestUsersWithHooks(IDataProvider dataProvider, int num)
        {
            // register the start hook

            // register the end hook

            // call GetTopOldestUsers with the hooks registered
            return GetTopOldestUsers(dataProvider, num);
        }

        // write the function that gets called when GetUsers starts

        // write the function that gets called when GetUsers finishes
    }
}
