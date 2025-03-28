using System;
using System.IO;

namespace Core
{
    public sealed class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private readonly string _logFilePath; 
        
        public enum LogLevel
        {
            Info,
            Warning,
            Error,
        };
        
        private Logger() 
        {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            _logFilePath = Path.Combine(logDirectory, "log.txt");
        }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            string logMessage = $"{DateTime.Now} [{level}] {message}";
            WriteToFile(logMessage);
        }

        private void WriteToFile(string message)
        {
            using (StreamWriter writer = new StreamWriter(_logFilePath, true)) // Always append mode
            {
                writer.WriteLine(message);
            }
        }
    }
}
