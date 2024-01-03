namespace Crud.Dtos
{

    public class StoreProductDto : BaseDto
    {
        public int SubCategoryId { get; set; }
        public string Description { get; set; }
        //public IFormFile image { get; set; }    
    }
}
