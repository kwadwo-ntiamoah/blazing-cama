using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Item
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonIgnore]
        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }
        [JsonPropertyName("category")]
        public Category Category { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set;}
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("discount")]
        public int Discount { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonPropertyName("images")]
        public List<string> Images { get; set; }
        [JsonPropertyName("inStock")]
        public bool InStock { get; set; } = true;
    }
}
