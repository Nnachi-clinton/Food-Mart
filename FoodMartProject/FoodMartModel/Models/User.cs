using FoodMartDomain.Cart;
using Microsoft.AspNetCore.Identity;

namespace FoodMartModel.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public string HistoryId { get; set; }
        public IEnumerable<History> Histories { get; set; }

    }
}
