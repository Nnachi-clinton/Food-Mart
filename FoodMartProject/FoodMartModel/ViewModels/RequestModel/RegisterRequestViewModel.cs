using System.ComponentModel.DataAnnotations;

namespace FoodMartDomain.ViewModels.RequestModel
{
    public class RegisterRequestViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set;}

    }
}
