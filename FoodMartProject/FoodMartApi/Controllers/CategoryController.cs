using FoodMartCore.IServices;
using FoodMartDomain.ViewModels.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _categoryService.GetCategoriesAsync();
            return StatusCode(response.ResponseCode, response);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(string categoryId)
        {
            var response = await _categoryService.GetCategoryByIdAsync(categoryId);
            return StatusCode(response.ResponseCode, response);
        }

        [HttpPost("Create/")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryRequestViewModel categoryRequest)
        {
            var response = await _categoryService.CreateCategoryAsync(categoryRequest);
            return StatusCode(response.ResponseCode, response);
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(string categoryId, [FromBody] CategoryRequestViewModel categoryRequest)
        {
            var response = await _categoryService.UpdateCategoryAsync(categoryId, categoryRequest);
            return StatusCode(response.ResponseCode, response);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(string categoryId)
        {
            var response = await _categoryService.DeleteCategoryAsync(categoryId);
            return StatusCode(response.ResponseCode, response);
        }
    }
}
