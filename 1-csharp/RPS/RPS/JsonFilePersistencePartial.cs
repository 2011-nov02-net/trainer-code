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

    public partial class JsonFilePersistence
    {
        public async Task WriteAsync(Score data)
        {
            // ways to work with JSON in .NET:
            //  - DataContractSerializer (built-in, semi-old)
            //  - System.Text.Json (built-in, new, fast)
            //  - Newtonsoft.Json (aka JSON.NET, very popular 3rd party)

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            // write the string to a new file at _filePath
            //File.WriteAllText(_filePath, json);

            // version 1 (but we should handle exceptions)
            //var writer = new StreamWriter(_filePath);
            //writer.Write(json);
            //writer.Close(); // need to call Close or Dispose on any object that contacts stuff outside the CLR (disk, network, OS calls)

            // version 2
            //StreamWriter writer = null;
            //try
            //{
            //    writer = new StreamWriter(_filePath);
            //    writer.Write(json);
            //}
            //finally
            //{
            //    // finally block is mostly for cleaning up resources that should be cleaned up regardless of success or failure.
            //    writer?.Close();
            //}
            // try vs catch vs finally.
            // try: put the code that might throw an exception you want to react to.
            // catch: for exceptions we can handle, handle them
            //        for exceptions we can't handle, we might e.g. log them, but re-throw them. "throw;"
            // finally: run if there was no exception, or if there was an uncaught exception, or if there was a caught exception
            //      (i.e. always every time)

            // version 3
            // (equivalent to version 2, but much nicer to write and look at)
            //using (var writer = new StreamWriter(_filePath))
            //{
            //    writer.Write(json);
            //}

            //
            using var writer = new StreamWriter(_filePath); // a newer form of the using statement; does the same thing
                        // calls dispose when the variable goes out of scope (the next } wherever it is)
            //writer.Write(json);
            await writer.WriteAsync(json);

            // when you instantiate any class that implements IDisposable interface, use a using statement to handle cleaning it up.
        }
    }
}
