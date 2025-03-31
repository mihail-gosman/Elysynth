using System;
using System.IO;

namespace Core
{
    /// <summary>
    /// Singleton Logger class that provides logging functionality for the application.
    /// Ensures only one instance of Logger is created and used across the entire application.
    /// </summary>
    public sealed class Logger
    {
        // Singleton instance of the Logger class
        private static Logger _instance;

        // Lock object to ensure thread-safe access to the Logger instance
        private static readonly object _lock = new object();

        // File path for the log file where all log entries will be written
        private readonly string _logFilePath;

        /// <summary>
        /// Enum representing the different log levels. Useful for categorizing log messages.
        /// </summary>
        public enum LogLevel
        {
            Info,    // Informational messages
            Warning, // Warnings that may indicate potential issues
            Error,   // Errors that need attention or intervention
        };

        /// <summary>
        /// Private constructor to enforce the Singleton pattern, preventing external instantiation.
        /// Initializes the log file and ensures the log directory exists.
        /// </summary>
        private Logger()
        {
            // Define the path to the 'Logs' directory within the application's base directory
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            // If the 'Logs' directory doesn't exist, create it
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Define the full path for the log file
            _logFilePath = Path.Combine(logDirectory, "log.txt");
        }

        /// <summary>
        /// Public property to access the Singleton instance of the Logger class.
        /// Ensures that only one instance of Logger exists across all threads.
        /// </summary>
        public static Logger Instance
        {
            get
            {
                // Lock to ensure thread-safe lazy instantiation of the Logger instance
                lock (_lock)
                {
                    // If the instance is null, create it
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Log a message to the log file with a specified log level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="level">The severity level of the log message. Default is 'Info'.</param>
        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            // Format the log message with the current timestamp and log level
            string logMessage = $"{DateTime.Now} [{level}] {message}";

            // Write the formatted log message to the log file
            WriteToFile(logMessage);
        }

        /// <summary>
        /// Writes a log message to the log file. Appends the message to the file.
        /// </summary>
        /// <param name="message">The log message to write to the file.</param>
        private void WriteToFile(string message)
        {
            // Open the log file in append mode. If the file doesn't exist, it will be created.
            using (StreamWriter writer = new StreamWriter(_logFilePath, true))
            {
                // Write the log message to the file, ensuring each log entry is on a new line
                writer.WriteLine(message);
            }
        }
    }
}
