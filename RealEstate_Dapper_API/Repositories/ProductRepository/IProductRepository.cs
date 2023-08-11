using RealEstate_Dapper_API.Dtos.ProductDtos;
using RealEstate_Dapper_API.Dtos.ProductRepository;

namespace RealEstate_Dapper_API.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync();

        //Task AddProductAsync(CreateProductDto productToAdd);
        //Task DeleteProductAsync(int productId);
        //Task UpdateProductAsync(UpdateProductDto productToUpdate);
        //Task<GetByIdProductDto> GetProductByIdAsync(int productId);

    }
}
