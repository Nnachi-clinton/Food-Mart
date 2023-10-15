using System.ComponentModel.DataAnnotations;

namespace FoodMartDomain.ViewModels.RequestModel
{
    public class LoginRequestViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
