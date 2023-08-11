using Dapper;
using RealEstate_Dapper_API.Dtos.CategoryDtos;
using RealEstate_Dapper_API.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(CreateCategoryDto categoryToAdd)
        {
            var parameters = new
            {
                categoryName = categoryToAdd.CategoryName,
                categoryStatus = true
            };

            string query = "INSERT INTO categories (CategoryName, CategoryStatus) VALUES (@categoryName, @categoryStatus)";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var parameters = new { id = categoryId };
            string query = "DELETE FROM categories WHERE Id = @id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            string query = "SELECT * FROM Categories";

            using (var connection = _context.CreateConnection())
            {
                var categories = await connection.QueryAsync<ResultCategoryDto>(query);
                return categories.AsList();
            }
        }

        public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            string query = "SELECT * FROM Categories WHERE Id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("@id", categoryId);

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto categoryToUpdate)
        {
            var parameters = new
            {
                id = categoryToUpdate.Id,
                categoryName = categoryToUpdate.CategoryName,
                categoryStatus = categoryToUpdate.CategoryStatus
            };

            string query = "UPDATE Categories SET CategoryName = @categoryName, CategoryStatus = @categoryStatus WHERE Id = @id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
