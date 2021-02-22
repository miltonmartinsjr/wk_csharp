using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    class MvcTempContext : DbContext
    {
        public MvcTempContext (DbContextOptions<MvcTempContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Cours> Cours { get; set; }
    }

}