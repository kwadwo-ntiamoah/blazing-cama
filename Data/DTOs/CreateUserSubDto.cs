using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class CreateUserSubDto
    {
        [Required]
        [JsonPropertyName("suscription_id")]
        public int SubscriptionId { get; set; }
    }
}
