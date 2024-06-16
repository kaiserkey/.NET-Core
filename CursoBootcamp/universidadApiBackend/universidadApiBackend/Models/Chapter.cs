using System.ComponentModel.DataAnnotations;

namespace universidadApiBackend.Models
{
    public class Chapter : BaseEntity
    {

        [Required]
        public string List = string.Empty;

        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();

    }
}
