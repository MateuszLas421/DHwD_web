using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DHwD_web.Models
{
    public class AppWebDbContext : DbContext
    {
        public AppWebDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Points> Points { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMembers> TeamMembers { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Place> Place { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.Points)
                .WithOne(b => b.User)
                .HasForeignKey<Points>(b => b.UserId);
            modelBuilder.Entity<User>()
                .HasMany(c => c.Teams)
                .WithOne(e => e.Id_Founder);
            modelBuilder.Entity<User>()
                .HasMany(c => c.TeamMembers)
                .WithOne(e => e.User);
            modelBuilder.Entity<Team>()
                .HasMany(c => c.TeamMembers)
                .WithOne(e => e.Team);
            modelBuilder.Entity<Games>()
                .HasMany(c => c.Teams)
                .WithOne(e => e.Games);
            modelBuilder.Entity<Games>()
                .HasMany(c => c.Place)
                .WithOne(e => e.Games);
        }
    }
}
