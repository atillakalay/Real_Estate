using RealEstate_Dapper_API.Dtos.CategoryDtos;

namespace RealEstate_Dapper_API.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task AddCategoryAsync(CreateCategoryDto categoryToAdd);
        Task DeleteCategoryAsync(int categoryId);
        Task UpdateCategoryAsync(UpdateCategoryDto categoryToUpdate);
        Task<GetByIdCategoryDto> GetCategoryByIdAsync(int categoryId);
    }
}
