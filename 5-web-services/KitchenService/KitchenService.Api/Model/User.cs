using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KitchenService.Api.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<Note> Notes { get; set; }
    }
}