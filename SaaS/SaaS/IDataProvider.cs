using System;
using System.Collections.Generic;

namespace SaaS
{
    /// <summary>
    /// The IDataProvider interface, provides data from somewhere
    /// </summary>
    public interface IDataProvider
    {
        void OnGetUsersStartedSubscribe(EventHandler handler);
        void OnGetUsersFinishedSubscribe(EventHandler handler);

        /// <summary>
        /// Get the users
        /// </summary>
        /// <returns>The users</returns>
        IEnumerable<User> GetUsers();
    }
}
