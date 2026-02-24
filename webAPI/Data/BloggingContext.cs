using Microsoft.EntityFrameworkCore;
using CodeFirstNewDatabaseSample.Models;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample.Data
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
    }
}
