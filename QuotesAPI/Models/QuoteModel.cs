using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace QuotesAPI.Models
{
    public class QuoteModel
    {
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("quote")]
        public string Quote { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonIgnore]
        public DateTime CreationTime { get; set; }
        
        [JsonIgnore]
        public DateTime EditTime { get; set; }
    }
}
