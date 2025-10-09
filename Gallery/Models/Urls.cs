using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gallery.Models
{
    public class Urls
    {
        [JsonPropertyName("regular")]
        public string Regular {  get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }
    }
}
