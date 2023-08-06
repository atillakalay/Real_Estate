using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Dtos;
using RealEstate_Dapper_API.Repositories.CategoryRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryRepository.AddCategoryAsync(createCategoryDto);
            return Ok("Category is created.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return Ok("Kategori başarılı bir şekilde silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryRepository.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Category is updated.");
        }
    }
}
