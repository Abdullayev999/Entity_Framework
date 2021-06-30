using CodeFirstGamesSecond.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstGamesSecond
{
    [Keyless]
    public class Template
    {
        public string Name { get; set; }
        public int? Count { get; set; }
    }
    public class ApplicationContextDB : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Firma> Firms { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Country> Countries { get; set; } 
        public IQueryable<Template> TopFirmsByMaxCountGame(int top = 3) => FromExpression(() => TopFirmsByMaxCountGame(top));
        public IQueryable<Template> MaxFimaByCounGame() => FromExpression(() => MaxFimaByCounGame());
        public IQueryable<Template> TopStyleByMaxCountGame(int top = 3) => FromExpression(() => TopStyleByMaxCountGame(top));
        public IQueryable<Template> PopulationStyleByCountGame() => FromExpression(() => PopulationStyleByCountGame());
        public IQueryable<Template> TopStyleBySalesCountGame(int top = 3) => FromExpression(() => TopStyleBySalesCountGame(top)); 
        public IQueryable<Template> PopulationStyleBySalesGame() => FromExpression(() => PopulationStyleBySalesGame());
        public IQueryable<Template> TopGameByNotMultiplayerByCountSales(int top = 3) => FromExpression(() => TopGameByNotMultiplayerByCountSales(top));
        public IQueryable<Template> TopGameByMultiplayerByCountSales(int top = 3) => FromExpression(() => TopGameByMultiplayerByCountSales(top));
        public IQueryable<Template> PopulationGameByNotMultiplayerByCountSales() => FromExpression(() => PopulationGameByNotMultiplayerByCountSales());
        public IQueryable<Template> PopulationGameByMultiplayerByCountSales() => FromExpression(() => PopulationGameByMultiplayerByCountSales());
        public IQueryable<Template> PopulationGamByCountSales() => FromExpression(() => PopulationGamByCountSales());
        public ApplicationContextDB()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
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


            modelBuilder.HasDbFunction(() => TopFirmsByMaxCountGame(default));
            modelBuilder.HasDbFunction(() => MaxFimaByCounGame());
            modelBuilder.HasDbFunction(() => TopStyleByMaxCountGame(default));
            modelBuilder.HasDbFunction(() => PopulationStyleByCountGame());
            modelBuilder.HasDbFunction(() => TopStyleBySalesCountGame(default)); 
            modelBuilder.HasDbFunction(() => PopulationStyleBySalesGame());
            modelBuilder.HasDbFunction(() => TopGameByNotMultiplayerByCountSales(default));
            modelBuilder.HasDbFunction(() => TopGameByMultiplayerByCountSales(default));
            modelBuilder.HasDbFunction(() => PopulationGameByNotMultiplayerByCountSales());
            modelBuilder.HasDbFunction(() => PopulationGameByMultiplayerByCountSales()); 
            modelBuilder.HasDbFunction(() => PopulationGamByCountSales());

        }
    }
}
