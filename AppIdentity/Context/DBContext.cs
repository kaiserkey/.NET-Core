using AppIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppIdentity.Context
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    }
}
