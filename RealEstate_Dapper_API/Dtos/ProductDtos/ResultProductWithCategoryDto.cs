using RealEstate_Dapper_API.Dtos.ProductRepository;

namespace RealEstate_Dapper_API.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto : ResultProductDto
    {
        public string CategoryName { get; set; }
    }
}
