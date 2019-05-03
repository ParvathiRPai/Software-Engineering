using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaS
{
    /// <summary>
    /// SqlMetricProvider singleton class, represents something that provides metrics from Sql
    /// </summary>
    public class SqlMetricProvider : IMetricProvider
    {
        /// <summary>
        /// The single provider instance
        /// </summary>
        private static SqlMetricProvider instance;

        /// <summary>
        /// Get the SqlMetricProvider instance
        /// </summary>
        /// <returns>A log instance</returns>
        public static SqlMetricProvider GetInstance()
        {
            if (instance == null)
                instance = new SqlMetricProvider();

            return instance;
        }

        /// <summary>
        /// Write a function duration metric
        /// </summary>
        /// <param name="functionName">The function name</param>
        /// <param name="start">The start time of the function</param>
        /// <param name="duration">The total duration of the function</param>
        public void WriteFunctionDuration(string functionName, DateTime start, TimeSpan duration)
        {
            using (var db = new SaaSEntities())
            {
                var fd = new FunctionDuration();
                fd.FunctionName = functionName;
                fd.StartTime = start;
                fd.DurationInMs = (long)duration.TotalMilliseconds;

                db.FunctionDurations.Add(fd);
                db.SaveChanges();
            }
        }
    }
}
