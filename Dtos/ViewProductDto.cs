using Crud.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Crud.Dtos
{

    public class ViewProductDto 
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string subCategoryName { get; set; }
        public string Description { get; set; }

    }
}
