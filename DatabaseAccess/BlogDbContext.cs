using DatabaseAccess.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
