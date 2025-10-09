using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gallery.Models
{
    public class Photo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("Created_At")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("alt_description")]
        public string AltDescription { get; set; }
        public string DisplayDescription => string.IsNullOrWhiteSpace(Description) ? AltDescription : Description;
        [JsonPropertyName("urls")]
        public Urls Urls { get; set; } 

        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}
