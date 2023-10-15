using FoodMartModel.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMartDomain.Cart
{
    public class History
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime PurchasedAt { get; set; }

        public string HistoryId { get; set; }

        public string ReferenceId { get; set; }

        public string ReferenceName { get; set; }
    }
}
