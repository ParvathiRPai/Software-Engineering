using System;
using System.IO;

namespace Logger
{
    /// <summary>
    /// Singleton Log class, provides ability to write to log files with different event types and log levels
    /// 
    /// The following shows how to use this class:
    /// 
    ///	var log = Log.GetInstance(@"E:\foo.txt");
	///
    ///	log.WriteLine(Log.EventType.Info, "This is an info line");
    ///	log.WriteLine(Log.EventType.Warning, "This is a warning line");
    ///	log.WriteLine(Log.EventType.Error, "This is an error line");
	///
    ///	log.CurrentLevel = Log.Level.Detailed;
    ///	log.WriteLine(Log.Level.Minimal, "This is a minimal log message. It should show up at any logging level");
    ///	log.WriteLine(Log.Level.Normal, "This is a normal log message. It should only show up if the current logging level is set to normal or detailed");
    ///	log.WriteLine(Log.Level.Detailed, "This is a detailed log message. It should only show up if the current logging level is set to detailed");
	/// 
    /// </summary>
    public class Log
    {
        /// <summary>
        /// The single log instance
        /// </summary>
        private static Log instance;

        /// <summary>
        /// Private constructor, called when GetInstance is called for the first time
        /// </summary>
        private Log()
        {
            CurrentLevel = Level.Normal;
        }

        /// <summary>
        /// The type of the log event
        /// </summary>
        public enum EventType
        {
            Info,
            Warning,
            Error
        }

        /// <summary>
        /// The log level
        /// </summary>
        public enum Level
        {
            Minimal,
            Normal,
            Detailed
        }

        /// <summary>
        /// The current log level
        /// </summary>
        public Level CurrentLevel { get; set; }

        /// <summary>
        /// The path to the log file
        /// </summary>
        public string Path { get; set; }

		/// <summary>
        /// Get the log instance
        /// </summary>
        /// <returns>A log instance</returns>
		public static Log GetInstance()
        {
            if (instance == null)
                instance = new Log();

            return instance;
        }

        /// <summary>
        /// Get the log instance, setting the log path at the same time
        /// </summary>
        /// <param name="path">The path to the log</param>
        /// <returns>A log instance</returns>
        public static Log GetInstance(string path)
        {
            var instance = GetInstance();
            instance.Path = path;

            return instance;
        }

        /// <summary>
        /// Write to the log using the specified logging level, event type, and message.
        /// Only calls to write with a level lower or equal to the current log level will be written.
        /// For example, if the current log level is Normal, and someone calls Write with Level.Detailed,
        /// that write will be ignored
        /// </summary>
        /// <param name="level">The log level for this log entry</param>
        /// <param name="eventType">The event type for this log entry</param>
        /// <param name="msg">The message</param>
        public void WriteLine(Level level, EventType eventType, string msg)
        {
            // if there is no file to write to, this is an error
            if (string.IsNullOrEmpty(Path))
                throw new InvalidOperationException("You must set the log path before trying to write");

            // if the specified level is higher than the current log level, ignore the write
            if ((int)level > (int)CurrentLevel)
                return;

            // otherwise, write a message in the following format:
            // [current date and time] - [event type] - message
            var logLine = $"[{DateTime.Now.ToString("G")}] - [{eventType.ToString()}] - {msg}";
            File.AppendAllText(Path, logLine + Environment.NewLine);
        }

		/// <summary>
        /// Overloaded WriteLine function, uses LogEventType.Info by default
        /// </summary>
        /// <param name="level">The log level for this log entry</param>
        /// <param name="msg">The message</param>
        public void WriteLine(Level level, string msg)
        {
            WriteLine(level, EventType.Info, msg);
        }

        /// <summary>
        /// Overloaded WriteLine function, uses LogLevel.Normal by default
        /// </summary>
        /// <param name="level">The event type for this log entry</param>
        /// <param name="msg">The message</param>
        public void WriteLine(EventType eventType, string msg)
        {
            WriteLine(Level.Normal, eventType, msg);
        }

		/// <summary>
        /// Overloaded WriteLine function, uses LogLevel.Normal and LogEventType.Info by default
        /// </summary>
        /// <param name="msg">The message</param>
        public void WriteLine(string msg)
        {
            WriteLine(Level.Normal, EventType.Info, msg);
        }
    }
}
