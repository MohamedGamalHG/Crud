using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Crud.Dtos
{
    public abstract class BaseDto
    {
        [JsonIgnore]
        public  int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
