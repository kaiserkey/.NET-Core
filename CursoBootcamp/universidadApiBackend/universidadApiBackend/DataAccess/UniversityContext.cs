using Microsoft.EntityFrameworkCore;
using universidadApiBackend.Models;


namespace universidadApiBackend.DataAccess
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options): base(options) {
            
        }

        // TODO: add dbsets (tables of our data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }

        }
}

