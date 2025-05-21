using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Cloner
{
    public static T DeepClone<T>(T obj)
    {
        if (obj == null)
            return default;

        using (var ms = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011 
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            return (T)formatter.Deserialize(ms);
#pragma warning restore SYSLIB0011
        }
    }
}
