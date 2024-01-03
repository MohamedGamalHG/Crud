using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        [ForeignKey("category")]
        public int category_id { get; set; }
        public Category category { get; set; }
        public DateTime ?CreatedAt { get; set; } = DateTime.Now;
        public DateTime ?UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Product> Products { get; set; }

    }

}
