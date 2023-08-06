using RealEstate_Dapper_API.Dtos;

namespace RealEstate_Dapper_API.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        public Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task AddCategoryAsync(CreateCategoryDto createCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    }
}
