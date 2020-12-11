using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KitchenClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.ParseAdd(MediaTypeNames.Application.Json);


            HttpResponseMessage response = await httpClient.PostAsync(
                "https://localhost:44336/api/notes/",
                new StringContent("{ \"text\": \"my note\" }", Encoding.UTF8, MediaTypeNames.Application.Json));


            string responseBodyString = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode(); // todo: why is this 415 🤔

            HttpResponseMessage response2 = await httpClient.GetAsync("https://localhost:44336/api/notes/3");

            //response.EnsureSuccessStatusCode(); // throws
            if (response2.IsSuccessStatusCode) // checks
            {
                // most serializers can handle strings or streams
                //string responseBodyString = await response.Content.ReadAsStringAsync();
                Stream response2BodyStream = await response2.Content.ReadAsStreamAsync();
                Note note = await JsonSerializer.DeserializeAsync<Note>(response2BodyStream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                Console.WriteLine($"{note.Id} {note.Author} {note.Text}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
