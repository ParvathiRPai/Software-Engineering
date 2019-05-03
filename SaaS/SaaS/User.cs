using System;

namespace SaaS
{
    /// <summary>
    /// The User class
    /// </summary>
    public class User
    {
        public int Ssn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}