using System.ComponentModel.DataAnnotations;

namespace universidadApiBackend.Models
{
    public class Student : BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateOnly DayOfBirt { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
