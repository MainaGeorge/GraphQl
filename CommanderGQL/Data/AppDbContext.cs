using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts): base(opts)
        {
        }

        public DbSet<Platform> Platforms { get; set; }  
    }
}
