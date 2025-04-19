using AuthenticationRole_base.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthenticationRole_base.Models;

namespace AuthenticationRole_base.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // ✅ Add Product DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ✅ Seeding Roles
            var admin = new IdentityRole
            {
                Id = "a2f88c3b-1c9d-4a97-a85f-61c8d74f24d8",
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            var user = new IdentityRole
            {
                Id = "b1d5a50e-2e62-45c6-917a-9e64a582f50h",
                Name = "user",
                NormalizedName = "USER"
            };

            var seller = new IdentityRole
            {
                Id = "c3f6f974-3b3b-4dd8-b345-e2e6a4d8c0b9",
                Name = "seller",
                NormalizedName = "SELLER"
            };

            builder.Entity<IdentityRole>().HasData(admin, user, seller);

            // ✅ Configure Product entity (Optional)
            builder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Brand).HasMaxLength(100);
                entity.Property(p => p.Category).HasMaxLength(100);
                entity.Property(p => p.Price).HasPrecision(16, 2);
                entity.Property(p => p.Quantity).IsRequired();
                entity.Property(p => p.Description).IsRequired(false);
                entity.Property(p => p.ImageFileName).HasMaxLength(100);
                entity.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            });
        }
        
    }
}
