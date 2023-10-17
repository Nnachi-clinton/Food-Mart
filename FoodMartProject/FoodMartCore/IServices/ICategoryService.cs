using FoodMartDomain.ViewModels;
using FoodMartDomain.ViewModels.RequestModel;
using FoodMartDomain.ViewModels.ResponseModel;

namespace FoodMartCore.IServices
{
    public interface ICategoryService
    {
        Task<Response<IEnumerable<CategoryResponseViewModel>>> GetCategoriesAsync();
        Task<Response<CategoryResponseViewModel>> GetCategoryByIdAsync(string categoryId);
        Task<Response<CategoryResponseViewModel>> CreateCategoryAsync(CategoryRequestViewModel categoryRequest);
        Task<Response<CategoryResponseViewModel>> UpdateCategoryAsync(string categoryId, CategoryRequestViewModel categoryRequest);
        Task<Response<bool>> DeleteCategoryAsync(string categoryId);
    }
}
