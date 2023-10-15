using FoodMartDomain.ViewModels;
using FoodMartDomain.ViewModels.RequestModel;
using FoodMartDomain.ViewModels.ResponseModel;
using FoodMartModel.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodMartCore.IServices
{
    public interface IUserLoginService
    {
        Task<Response<LoginResponseViewModel>> FindUserByEmailAsync(LoginRequestViewModel model);
        Task<SignInResult> CheckPasswordSignInAsync(User user, string password, bool lockoutOnFailure);
    }
}
