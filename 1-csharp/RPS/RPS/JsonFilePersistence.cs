using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RPS
{
    // besides JSON, we commonly use XML to store data
    // in .NET for XML, we can use...
    //  - DataContractSerializer (also supports JSON)
    //  - XmlSerializer (quite old, doesn't support generics)

    public class JsonFilePersistence
    {
        private readonly string _filePath;

        public JsonFilePersistence(string filePath)
        {
            _filePath = filePath;
        }

        public Score Read()
        {
            string json;
            try
            {
                json = File.ReadAllText(_filePath);
            }
            catch (IOException)
            {
                return new Score();
            }
            Score data = JsonSerializer.Deserialize<Score>(json);
            return data;
        }

        public void Write(Score data)
        {
            // ways to work with JSON in .NET:
            //  - DataContractSerializer (built-in, semi-old)
            //  - System.Text.Json (built-in, new, fast)
            //  - Newtonsoft.Json (aka JSON.NET, very popular 3rd party)

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            // write the string to a new file at _filePath
            File.WriteAllText(_filePath, json);
        }
    }
}
