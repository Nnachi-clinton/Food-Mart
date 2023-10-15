using FoodMartCommons.Validations;
using FoodMartCore.IServices;
using FoodMartDomain.ViewModels;
using FoodMartDomain.ViewModels.RequestModel;
using FoodMartDomain.ViewModels.ResponseModel;
using FoodMartModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodMartCore.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly GeneralValidator _generalValidator;
        

        public UserRegistrationService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, GeneralValidator generalValidator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _generalValidator = generalValidator;
        }       

        public async Task<Response<RegisterResponseViewModel>> RegisterAsync(RegisterRequestViewModel model, string roleName, ModelStateDictionary modelState)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var uniqueUser = await _generalValidator.ValidateUserAsync(user, model.Password);
            var response = new Response<RegisterResponseViewModel>();
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!uniqueUser.Succeeded)
            {
                var errors = uniqueUser.Errors.Select(e => e.Description).ToList();
                return response.Failed("Email already exists", StatusCodes.Status400BadRequest);
            
            }
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(roleName))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                    await _userManager.AddToRoleAsync(user, roleName);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        modelState.AddModelError(string.Empty, error.Description);
                    }
                }

                var status = new RegisterResponseViewModel
                {
                    UserName = user.UserName
                };

                return response.Success($"{status.UserName} created successfully", StatusCodes.Status200OK);
        }

        
    }
}
