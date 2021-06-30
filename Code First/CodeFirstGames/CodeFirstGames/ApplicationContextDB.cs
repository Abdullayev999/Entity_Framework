using CodeFirstGames.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstGames
{
    public class ApplicationContextDB : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Firma> Firms { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public ApplicationContextDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Gaming;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firma>().HasIndex(i => i.Name).IsUnique();
            modelBuilder.Entity<Style>().HasIndex(i => i.Name).IsUnique();
            modelBuilder.Entity<Game>().HasIndex(i => i.Name).IsUnique();
        }
    }
}
