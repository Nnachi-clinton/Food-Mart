using FoodMartDomain.ViewModels;
using FoodMartDomain.ViewModels.RequestModel;
using FoodMartDomain.ViewModels.ResponseModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodMartCore.IServices
{
    public interface IUserRegistrationService
    {
        Task<Response<RegisterResponseViewModel>> CreateUserAsync(RegisterRequestViewModel model, ModelStateDictionary modelState);

        Task<Response<RegisterResponseViewModel>> CreateVendorAsync(RegisterRequestViewModel model, ModelStateDictionary modelState);


    }
}
