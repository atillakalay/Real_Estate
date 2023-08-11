using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.ProductRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProdutList()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProdutListWithCategory()
        {
            var products = await _productRepository.GetAllProductsWithCategoryAsync();
            return Ok(products);
        }
    }
}
