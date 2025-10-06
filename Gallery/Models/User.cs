using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gallery.Models
{
    internal class User
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } 
    }
}
