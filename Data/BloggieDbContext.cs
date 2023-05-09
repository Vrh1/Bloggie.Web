using Microsoft.EntityFrameworkCore;
using udemyBloggie.Web.Models.Domain;

namespace udemyBloggie.Web.Data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
