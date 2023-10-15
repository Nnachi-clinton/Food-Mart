using FoodMartCore.IServices;
using FoodMartDomain.ViewModels;
using FoodMartDomain.ViewModels.RequestModel;
using FoodMartDomain.ViewModels.ResponseModel;
using FoodMartModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodMartCore.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserManager<User> _userManager;
       // private readonly UserManager<Vendor> _userManager1;
        private readonly RoleManager<IdentityRole> _roleManager;
        

        public UserRegistrationService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;       
            
        }

        public async Task<Response<RegisterResponseViewModel>> CreateUserAsync(RegisterRequestViewModel model, ModelStateDictionary modelState)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,               
            };
            var response = new Response<RegisterResponseViewModel>();
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }                
                await _userManager.AddToRoleAsync(user, "User");               
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

            return response.Success($"{status.UserName} Created successfully", StatusCodes.Status200OK);

        }

        public async Task<Response<RegisterResponseViewModel>> CreateVendorAsync(RegisterRequestViewModel model, ModelStateDictionary modelState)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
            };
            var response = new Response<RegisterResponseViewModel>();
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("Vendor"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Vendor"));
                }
                await _userManager.AddToRoleAsync(user, "Vendor");
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

            return response.Success($"{status.UserName} Created successfully", StatusCodes.Status200OK);
        }
    }
}
