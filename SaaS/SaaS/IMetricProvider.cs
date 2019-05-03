using System;

namespace SaaS
{
    /// <summary>
    /// IMetricProvider interface, represents something that provides metrics from somewhere
    /// </summary>
    public interface IMetricProvider
    {
        /// <summary>
        /// Write a function duration metric
        /// </summary>
        /// <param name="functionName">The function name</param>
        /// <param name="start">The start time of the function</param>
        /// <param name="duration">The total duration of the function</param>
        void WriteFunctionDuration(string functionName, DateTime start, TimeSpan duration);
    }
}