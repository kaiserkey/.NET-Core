using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Models.TodoItem> TodoItems { get; set; }
    }
}
