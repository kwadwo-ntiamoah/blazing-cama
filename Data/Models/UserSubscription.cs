using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class UserSubscription
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public bool Expired { get; set; } = false;
        public bool IsActive { get; set; } = false;
    }
}
