namespace ForumApp.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
	using ForumApp.Data.Configuration;

	public class ForumAppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; init; }

        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
        }

    }
}
