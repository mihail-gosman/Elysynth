using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Models;

namespace Core.Utilities
{
    /// <summary>
    /// Serializer class implementing Singleton pattern for handling serialization and deserialization of objects.
    /// This class uses binary serialization to write and read objects to/from files.
    /// </summary>
    public sealed class Serializer
    {
        // Singleton instance of the Serializer class
        private static Serializer _instance;

        // Lock object to ensure thread-safe access to the Singleton instance
        private static readonly object _lock = new object();

        /// <summary>
        /// Public property to access the Singleton instance of the Serializer class.
        /// Ensures that only one instance of Serializer exists across all threads.
        /// </summary>
        public static Serializer Instance
        {
            get
            {
                lock (_lock)
                {
                    // Create a new instance only if it does not already exist
                    if (_instance == null)
                    {
                        _instance = new Serializer();
                    }
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Serializes an object and writes it to a specified file.
        /// Ensures the target directory exists before writing to the file.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="filePath">The path where the serialized object should be saved.</param>
        /// <param name="model">The object to serialize and write to the file.</param>
        public void Write<T>(string filePath, T model)
        {
            string directoryPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, model);
            }
        }


        /// <summary>
        /// Deserializes an object from the specified file and returns the object.
        /// If the file does not exist or is empty, returns the default value of the type.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <param name="filePath">The path of the file to read the object from.</param>
        /// <returns>The deserialized object, or the default value of the type if an error occurs.</returns>
        public T Read<T>(string filePath)
        {
            // Check if the file path exists
            if (File.Exists(filePath))
            {
                // Open the file for reading
                using (FileStream fs = File.OpenRead(filePath))
                {
                    // Create a binary formatter for deserialization
                    IFormatter formatter = new BinaryFormatter();

                    // Deserialize the object from the file and return it
                    return (T)formatter.Deserialize(fs);
                }
            }

            // Return the default value of T if the file does not exist
            return default;
        }
    }
}
