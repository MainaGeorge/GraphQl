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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(new List<Platform>
            {
                new() { Name = "Dotnet", Id=1},
                new() { Name = "Linux", Id=2 },
                new() { Name = "Docker", Id=3},
                new() {Name = "PowerShell", Id = 4}
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
