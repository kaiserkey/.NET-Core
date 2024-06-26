﻿using System.ComponentModel.DataAnnotations;


namespace universidadApiBackend.Models
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;
        public DateTime DeletedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
