using FoodMartCore.IServices;
using FoodMartDomain.ViewModels.RequestModel;
using FoodMartDomain.ViewModels.ResponseModel;
using FoodMartDomain.ViewModels;
using FoodMartModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using FoodMartCommons.JWT;

namespace FoodMartCore.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;


        public UserLoginService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<Response<LoginResponseViewModel>> FindUserByEmailAsync(LoginRequestViewModel model)
        {
            var response = new Response<LoginResponseViewModel>();
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return response.Failed("User not found", StatusCodes.Status404NotFound);
            }

            var validatePassword = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);

            if (!validatePassword.Succeeded)
            {
                return response.Failed("You are not authorized", StatusCodes.Status401Unauthorized);
            }

            string role; 

            
            if (await _userManager.IsInRoleAsync(user, "Vendor"))
            {
                role = "Vendor";
            }
            else
            {
                role = "User";
            }

            var token = JWT.GenerateJwtToken(user, role, _configuration);
            var result = new LoginResponseViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Id = user.Id,
                Token = token
            };

            return response.Success("User logged in successfully", StatusCodes.Status200OK, result);

        }

        public async Task<SignInResult> CheckPasswordSignInAsync(User user, string password, bool lockoutOnFailure)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure);
        }

    }
}
