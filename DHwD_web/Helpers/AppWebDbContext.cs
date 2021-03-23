using DHwD_web.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DHwD_web.Helpers
{
    public class AppWebDbContext : DbContext
    {
        public AppWebDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Points> Points { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<TeamMembers> TeamMembers { get; set; }

        public DbSet<Games> Games { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<ActivePlace> ActivePlaces { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Mysterys> Mysterys { get; set; }

        public DbSet<Solutions> Solutions { get; set; }

        public DbSet<Chats> Chats { get; set; }
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

            modelBuilder.Entity<Status>()
                .HasOne(a => a.Team)
                .WithOne(b => b.Status)
                .HasForeignKey<Team>(b => b.StatusRef);

            modelBuilder.Entity<ActivePlace>()
                .HasMany(a => a.Status)
                .WithOne(b => b.ActivePlace);

            modelBuilder.Entity<Place>()
                .HasMany(a => a.ActivePlace)
                .WithOne(b => b.Place);

            modelBuilder.Entity<Place>()
                .HasOne(a => a.Location)
                .WithOne(b => b.Place)
                .HasForeignKey<Place>(b => b.LocationRef);

            modelBuilder.Entity<Solutions>()
                .HasOne(a => a.Mystery)
                .WithOne(b => b.Solutions)
                .HasForeignKey<Mysterys>(b => b.SolutionsRef);

            modelBuilder.Entity<Mysterys>()
                .HasOne(a => a.Location)
                .WithOne(b => b.Mysterys)
                .HasForeignKey<Location>(b => b.MysteryRef);

            modelBuilder.Entity<Chats>()
                .HasOne(a => a.Team)
                .WithMany(b => b.Chats);

            modelBuilder.Entity<Chats>()
                .HasOne(a => a.Game)
                .WithMany(b => b.Chats);
        }
    }
}
