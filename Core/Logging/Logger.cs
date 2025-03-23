using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Logger
    {
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
        private static readonly object _lock = new object();

        private string _logFilePath;
        private bool _logToConsole;

        public enum LogLevel 
        { 
            INFO, WARNING, ERROR, DEBUG 
        }

        
        private Logger()
        {
            
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "Elysynth.log");
            Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath)); 
            _logToConsole = true; 
        }

       
        public static Logger Instance => _instance.Value;

        public void Configure(string logFilePath, bool logToConsole = true)
        {
            lock (_lock)
            {
                _logFilePath = logFilePath;
                Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath));
                _logToConsole = logToConsole;
            }
        }

        
        public void Log(string message, LogLevel level = LogLevel.INFO)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}";

            lock (_lock)
            {
                File.AppendAllText(_logFilePath, logEntry + Environment.NewLine, Encoding.UTF8);

          
            }
        }

    }
}
