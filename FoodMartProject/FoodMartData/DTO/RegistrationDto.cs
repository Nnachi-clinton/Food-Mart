using System.ComponentModel.DataAnnotations;

namespace FoodMartDomain.DTO
{
    public class RegistrationDto
    {

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
