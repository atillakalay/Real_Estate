namespace RealEstate_Dapper_API.Dtos
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
