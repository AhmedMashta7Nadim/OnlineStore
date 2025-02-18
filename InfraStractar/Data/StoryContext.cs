using Microsoft.EntityFrameworkCore;
using Models_Entity.Models;

namespace InfraStractar.Data
{
    public class StoryContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Application> applications { get; set; }
        public DbSet<UserApplication> userApplications { get; set; }


        public static string database = "Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog=Story_db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(database);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasIndex(x => x.Email)
                        .IsUnique();


            modelBuilder.Entity<Application>()
                .HasMany(x => x.Users)
                .WithMany(x => x.applications)
                .UsingEntity<UserApplication>();

            modelBuilder.Entity<Application>()
                .HasMany(x => x.User_Developer)
                .WithMany(x => x.applications)
                .UsingEntity<UserApplication>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
