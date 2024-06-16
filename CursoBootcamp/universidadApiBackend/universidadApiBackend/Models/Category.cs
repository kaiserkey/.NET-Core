using System.ComponentModel.DataAnnotations;

namespace universidadApiBackend.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Course> Categories { get; set; } = new List<Course>();
    }
}
