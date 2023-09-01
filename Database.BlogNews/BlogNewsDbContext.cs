using Database.BlogNews.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Database.BlogNews
{
    public class BlogNewsDbContext : IdentityDbContext
    {
        public BlogNewsDbContext(DbContextOptions<BlogNewsDbContext> options) : base(options)
        {
        }

        public DbSet<Noticia> Noticias { get; set; }

    }
}
