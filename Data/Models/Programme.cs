using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Programme
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("time")]
        public string Time { get; set; }
        [JsonIgnore]
        public int DayId { get; set; }
        [JsonIgnore]
        public Day Day { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;
    }
}
