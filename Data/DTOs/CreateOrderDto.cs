using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class OrderItemDto
    {
        [Required]
        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }
        [Required]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }


    public class CreateOrderDto
    {
        [Required]
        [JsonPropertyName("order_items")]
        public List<OrderItemDto> OrderItems { get; set; }
        [Required]
        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; }
        [Required]
        [JsonPropertyName("customer_email")]
        public string CustomerEmail { get; set; }
        [Required]
        [JsonPropertyName("customer_phone")]
        public string CustomerPhone { get; set; }
        [Required]
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [Required]
        [JsonPropertyName("cityTown")]
        public string CityTown { get; set; }
    }
}
