using FoodMartModel.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodMartCommons.Validations
{
    public class GeneralValidator
    {
        private readonly UserManager<User> _userManager;
        private readonly UserManager<Vendor> _userManager1;

        public GeneralValidator(UserManager<User> userManager, UserManager<Vendor> userManager1)
        {
            _userManager = userManager;
            _userManager1 = userManager1    ;
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


        public async Task<IdentityResult> ValidateVendorAsync(Vendor vendor, string password)
        {
            var usernameExists = await _userManager1.FindByNameAsync(vendor.UserName) != null;
            if (usernameExists)
            {
                return IdentityResult.Failed(new IdentityError { Code = "DuplicateUserName", Description = "Username already exists" });
            }

            var emailExists = await _userManager1.FindByEmailAsync(vendor.Email) != null;
            if (emailExists)
            {
                return IdentityResult.Failed(new IdentityError { Code = "DuplicateEmail", Description = "Email already exists" });
            }

            var result = await _userManager1.PasswordValidators.First().ValidateAsync(_userManager1, vendor, password);
            if (!result.Succeeded)
            {
                return result;
            }

            return IdentityResult.Success;
        }


    }
}
