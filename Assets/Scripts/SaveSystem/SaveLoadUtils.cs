using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveSystem
{
    public static class SaveLoadUtils
    {
        public static void Save<T>(T data, string filename) where T : class
        {
            var binaryFormatter = new BinaryFormatter();
            var path = $"{Application.persistentDataPath}/{filename}.class";
            var fileStream = new FileStream(path, FileMode.Create);
            binaryFormatter.Serialize(fileStream, data);
            fileStream.Close();
        }
        
        public static T Load<T>(string filename) where T : class 
        {
            var path = $"{Application.persistentDataPath}/{filename}.class";
            FileStream fileStream;
            try
            {
                fileStream = new FileStream(path, FileMode.Open);
            }
            catch (FileNotFoundException e)
            {
                Debug.Log("file doesn't exist");
                return null;
            }

            if (File.Exists(path) && fileStream.Length > 0)
            {
                var binaryFormatter = new BinaryFormatter();
                var data = binaryFormatter.Deserialize(fileStream) as T;
                fileStream.Close();
                return data;
            }
            Debug.Log("file doesn't exist");
            return null;
        }
    }
}