using FoodMartCore.IServices;
using FoodMartDomain.ViewModels;
using FoodMartDomain.ViewModels.RequestModel;
using FoodMartDomain.ViewModels.ResponseModel;
using FoodMartInfrastructure.DbContext;
using FoodMartModel;
using Microsoft.EntityFrameworkCore;

namespace FoodMartCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FoodDbContext _context;

        public CategoryService(FoodDbContext context)
        {
            _context = context;
        }

        public async Task<Response<IEnumerable<CategoryResponseViewModel>>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _context.Categories
                    .Include(c => c.Products)
                    .ToListAsync();

                var categoryResponses = categories.Select(category => new CategoryResponseViewModel
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    Products = category.Products.Select(product => new ProductResponseViewModel
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                    }).ToList()
                }).ToList();

                return new Response<IEnumerable<CategoryResponseViewModel>>().Success("Categories retrieved successfully", 200, categoryResponses);
            }
            catch (Exception)
            {
                return new Response<IEnumerable<CategoryResponseViewModel>>().Failed("Failed to retrieve categories", 500);
            }
        }

        public async Task<Response<CategoryResponseViewModel>> GetCategoryByIdAsync(string categoryId)
        {
            try
            {
                var category = await _context.Categories
                    .Include(c => c.Products)
                    .FirstOrDefaultAsync(c => c.Id == categoryId);

                if (category == null)
                {
                    return new Response<CategoryResponseViewModel>().Failed("Category not found.", 404);
                }

                var categoryResponse = new CategoryResponseViewModel
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    Products = category.Products.Select(product => new ProductResponseViewModel
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                    }).ToList()
                };

                return new Response<CategoryResponseViewModel>().Success("Category retrieved successfully", 200, categoryResponse);
            }
            catch (Exception)
            {
                return new Response<CategoryResponseViewModel>().Failed("Failed to retrieve the category", 500);
            }
        }

        public async Task<Response<CategoryResponseViewModel>> CreateCategoryAsync(CategoryRequestViewModel categoryRequest)
        {
            try
            {
                var newCategory = new Categories
                {
                    CategoryName = categoryRequest.CategoryName,
                };

                _context.Categories.Add(newCategory);
                await _context.SaveChangesAsync();

                var categoryResponse = new CategoryResponseViewModel
                {
                    Id = newCategory.Id,
                    CategoryName = newCategory.CategoryName,
                };

                return new Response<CategoryResponseViewModel>().Success("Category created successfully", 201, categoryResponse);
            }
            catch (Exception)
            {
                return new Response<CategoryResponseViewModel>().Failed("Failed to create the category", 500);
            }
        }

        public async Task<Response<CategoryResponseViewModel>> UpdateCategoryAsync(string categoryId, CategoryRequestViewModel categoryRequest)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

                if (category == null)
                {
                    return new Response<CategoryResponseViewModel>().Failed("Category not found.", 404);
                }

                category.CategoryName = categoryRequest.CategoryName;

                await _context.SaveChangesAsync();

                var categoryResponse = new CategoryResponseViewModel
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                };

                return new Response<CategoryResponseViewModel>().Success("Category updated successfully", 200, categoryResponse);
            }
            catch (Exception)
            {
                return new Response<CategoryResponseViewModel>().Failed("Failed to update the category", 500);
            }
        }

        public async Task<Response<bool>> DeleteCategoryAsync(string categoryId)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

                if (category == null)
                {
                    return new Response<bool>().Failed("Category not found.", 404);
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return new Response<bool>().Success("Category deleted successfully", 200, true);
            }
            catch (Exception)
            {
                return new Response<bool>().Failed("Failed to delete the category", 500);
            }
        }
    }
}
