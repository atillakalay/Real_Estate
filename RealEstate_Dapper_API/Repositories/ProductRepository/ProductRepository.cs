using Dapper;
using RealEstate_Dapper_API.Dtos.ProductDtos;
using RealEstate_Dapper_API.Dtos.ProductRepository;
using RealEstate_Dapper_API.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        //public Task AddProductAsync(CreateProductDto productToAdd)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteProductAsync(int productId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            string query = "SELECT * FROM Products";

            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<ResultProductDto>(query);
                return products.AsList();
            }

        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync()
        {
            string query = "SELECT P.Id, P.Title, C.CategoryName AS CategoryName FROM Products AS P INNER JOIN Categories AS C ON P.ProductCategory = C.Id";

            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return products.AsList();
            }
        }


        //public Task<GetByIdProductDto> GetProductByIdAsync(int productId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateProductAsync(UpdateProductDto productToUpdate)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
