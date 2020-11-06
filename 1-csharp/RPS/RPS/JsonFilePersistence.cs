using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RPS
{
    // besides JSON, we commonly use XML to store data
    // in .NET for XML, we can use...
    //  - DataContractSerializer (also supports JSON)
    //  - XmlSerializer (quite old, doesn't support generics)

    // whenever you interact with things outside .NET like the disk or the network
    // 1. the class is probably IDisposable, you should probably make sure to use a using statement or otherwise call Dispose / Close
    // 2. consider making the long-running calls "async" if other useful work can be done in the meantime.

    public partial class JsonFilePersistence
    {
        private readonly string _filePath;

        public JsonFilePersistence(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<Score> ReadAsync()
        {
            string json;
            try
            {
                //json = File.ReadAllText(_filePath);
                Task<string> jsonTask = File.ReadAllTextAsync(_filePath);
                json = await jsonTask;
            }
            catch (IOException)
            {
                return new Score();
            }
            Score data = JsonSerializer.Deserialize<Score>(json);
            return data;
        }

        // steps to go async:
        // 1. look for a version of the method you want to call that ends in the "Async" prefix that returns a Task. call that instead.
        // 2. now you have a Task instead of the thing you wanted. either await it right away, or, if you can do something useful in the meantime,
        //        do that first.
        // 3. compile error: method must be async. add "async" to method. change return type: void becomes Task, any T becomes Task<T>.
        //        also, by convention, add the "Async" suffix to your own method.
        // 4. any code that calls this method: start from step 1.
    }
}
