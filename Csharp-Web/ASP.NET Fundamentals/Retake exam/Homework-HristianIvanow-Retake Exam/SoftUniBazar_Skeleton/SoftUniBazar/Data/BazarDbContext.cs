namespace SoftUniBazar.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class BazarDbContext : IdentityDbContext
    {
        public DbSet<Ad> Ads { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<AdBuyer> AdsBuyers { get; set; }

        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdBuyer>()
                .HasOne(ab => ab.Ad)
                .WithMany(a => a.AdBuyers)
                .HasForeignKey(ab => ab.AdId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdBuyer>()
                .HasKey(ab => new {ab.BuyerId, ab.AdId});

            modelBuilder.Entity<Ad>()
                .Property(b => b.Price)
                .HasColumnType("decimal")
                .HasPrecision(18, 2);

            modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cars"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Technology"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}