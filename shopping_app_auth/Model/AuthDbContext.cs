using Microsoft.EntityFrameworkCore;
using shopping_app_auth.Model.Models;

namespace shopping_app_auth.Model
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            base.OnModelCreating(builder);

        }
    }
}
