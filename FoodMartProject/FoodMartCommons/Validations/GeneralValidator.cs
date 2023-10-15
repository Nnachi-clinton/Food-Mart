using FoodMartModel.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodMartCommons.Validations
{
    public class GeneralValidator
    {
        private readonly UserManager<User> _userManager;
        

        public GeneralValidator(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> ValidateUserAsync(User user, string password)
        {
            var usernameExists = await _userManager.FindByNameAsync(user.UserName) != null;
            if (usernameExists)
            {
                return IdentityResult.Failed(new IdentityError { Code = "DuplicateUserName", Description = "Username already exists" });
            }

            var emailExists = await _userManager.FindByEmailAsync(user.Email) != null;
            if (emailExists)
            {
                return IdentityResult.Failed(new IdentityError { Code = "DuplicateEmail", Description = "Email already exists" });
            }

            var result = await _userManager.PasswordValidators.First().ValidateAsync(_userManager, user, password);
            if (!result.Succeeded)
            {
                return result;
            }

            return IdentityResult.Success;
        }


      


    }
}
