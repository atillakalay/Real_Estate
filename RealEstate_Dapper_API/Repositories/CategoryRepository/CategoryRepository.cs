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

        public async void AddCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into categories (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
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
                return values.ToList();
            }
        }
    }
}
