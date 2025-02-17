using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models_Entity.Models;

namespace InfraStractar.Data
{
    public class StoryContext:DbContext
    {
        public DbSet<User> users { get; set; }



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

            base.OnModelCreating(modelBuilder);
        }

    }
}
