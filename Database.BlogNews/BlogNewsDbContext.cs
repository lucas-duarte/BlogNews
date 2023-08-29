using Database.BlogNews.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Database.BlogNews
{
    public class BlogNewsDbContext : DbContext
    {
        public BlogNewsDbContext(DbContextOptions<BlogNewsDbContext> options) : base(options)
        {
        }

        public DbSet<Noticia> Noticias { get; set; }

    }
}
