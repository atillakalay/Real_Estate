using Dapper;
using RealEstate_Dapper_API.Dtos;
using RealEstate_Dapper_API.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _applicationContext;

        public CategoryRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task AddCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var parameters = new { categoryName = createCategoryDto.CategoryName, categoryStatus = true };
            string query = "INSERT INTO categories (CategoryName, CategoryStatus) VALUES (@categoryName, @categoryStatus)";

            using (var connection = _applicationContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var parameters = new { id };
            string query = "DELETE FROM categories WHERE Id = @id";

            using (var connection = _applicationContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "SELECT * FROM Categories";

            using (var connection = _applicationContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.AsList();
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var parameters = new { id = updateCategoryDto.Id, categoryName = updateCategoryDto.CategoryName, categoryStatus = updateCategoryDto.CategoryStatus };
            string query = "UPDATE Categories SET CategoryName = @categoryName, CategoryStatus = @categoryStatus WHERE Id = @id";

            using (var connection = _applicationContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
