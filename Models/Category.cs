namespace Crud.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime ?CreatedAt { get; set; } = DateTime.Now;
        public DateTime ?UpdatedAt { get; set; } = DateTime.Now;
        public ICollection<SubCategory> SubCategory { get; set; } 


    }
}
