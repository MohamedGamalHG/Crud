using Crud.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Crud.Dtos
{

    public class ViewSubCategoryDto 
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string category_name { get; set; }
    }
}
