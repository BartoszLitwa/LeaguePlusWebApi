using LeaguePlus.Core;
using Microsoft.EntityFrameworkCore;

namespace LeaguePlus.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users;
    }
}
