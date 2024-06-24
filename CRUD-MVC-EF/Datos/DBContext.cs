using CRUD_MVC_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC_EF.Datos
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        // agregar los modelos aqui (cada modelo corresponde a una tabla de la base de datos)

        public DbSet<Contacto> Contacto { get; set; }
    }
}
