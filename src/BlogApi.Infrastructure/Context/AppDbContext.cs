using BlogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BlogPost> BlogPost => Set<BlogPost>();
        public DbSet<Comment> Comment => Set<Comment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId);
        }

    }
}
