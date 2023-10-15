using FoodMartDomain.ViewModels;
using FoodMartDomain.ViewModels.RequestModel;
using FoodMartDomain.ViewModels.ResponseModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodMartCore.IServices
{
    public interface IUserRegistrationService
    {
       Task<Response<RegisterResponseViewModel>> RegisterAsync(RegisterRequestViewModel model, string roleName, ModelStateDictionary modelState);


    }
}
