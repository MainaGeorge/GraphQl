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
        public DbSet<Command> Commands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(new List<Platform>
            {
                new() { Name = "Dotnet", Id=1},
                new() { Name = "Linux", Id=2 },
                new() { Name = "Docker", Id=3},
                new() {Name = "PowerShell", Id = 4}
            });

            modelBuilder.Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(p => p.Platform)
                .HasForeignKey(p => p.PlatformId);

            modelBuilder.Entity<Command>()
                .HasOne(p => p.Platform)
                .WithMany(c => c.Commands)
                .HasForeignKey(c => c.PlatformId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
