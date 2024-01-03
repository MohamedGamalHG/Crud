using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       // public string ?Image { get; set; }
        [ForeignKey("SubCategory")]
        public int subcategory_id { get; set; }
        public SubCategory SubCategory { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
