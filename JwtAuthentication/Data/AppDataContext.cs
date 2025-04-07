using JwtAuthentication.Model;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
        public DbSet<Login> ?Logins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasKey(l => l.LoginId);
        }
    }
}
