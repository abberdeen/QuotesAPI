using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AlifQuotesAPI.Models
{
    public class QuoteModel
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public string Quote { get; set; }
        public string Category { get; set; }
        public string CreationTime { get; set; }
        public string EditTime { get; set; }
    }
}
