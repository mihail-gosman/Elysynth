using System;
using System.IO;

namespace Core.Logging
{
    public class Logger
    {
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
        private readonly string _logFilePath;

        public enum LogLevel
        {
            Info,
            Warning,
            Error
        };

        public static Logger Instance => _instance.Value;

        private Logger()
        {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            _logFilePath = Path.Combine(logDirectory, "log.txt");
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            string logMessage = $"{DateTime.Now:yyyy:MM:dd HH:mm:ss} [{level}] {message}";
            WriteToFile(logMessage);
        }

        private void WriteToFile(string message)
        {
            try
            {
                if (!File.Exists(_logFilePath))
                {
                    using (StreamWriter writer = File.CreateText(_logFilePath))
                    {
                        writer.WriteLine(message);
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(_logFilePath, true))
                    {
                        writer.WriteLine(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}
