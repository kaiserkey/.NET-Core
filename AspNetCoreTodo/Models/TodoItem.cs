using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodo.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        [Required]
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyyTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? DueAt { get; set; }
    }
}
