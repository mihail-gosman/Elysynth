using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Models;

namespace Core.Utilities
{
    public sealed class Serializer 
    {
        private static Serializer _instance;
        private static readonly object _lock = new object();

        public static Serializer Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    { 
                        _instance = new Serializer();
                    }
                    return _instance; 
                }
            }
        }

        public void Write <T>(string filePath, T model)
        {
            string directoryPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (FileStream fs = File.OpenWrite(filePath))
            {
                IFormatter formatter = new BinaryFormatter();

                formatter.Serialize(fs, model);
            }
        }

        public T Read<T>(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                if (File.Exists(filePath))
                {
                    using (FileStream fs = File.OpenRead(filePath))
                    {
                        IFormatter formatter = new BinaryFormatter();

                        return (T)formatter.Deserialize(fs);
                    }
                }
            }
            return default;
        }
    }
}
