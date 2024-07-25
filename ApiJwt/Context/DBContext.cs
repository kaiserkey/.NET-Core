using ApiJwt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiJwt.Context
{
    public class DBContext : IdentityDbContext<User>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
    }
}
