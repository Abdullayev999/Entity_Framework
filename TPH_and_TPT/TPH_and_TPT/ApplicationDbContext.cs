using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH_and_TPT.Models;

namespace TPH_and_TPT
{
    public partial class ScalarInt
    {
        public int Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        // public DbSet<Manager> Managers { get; set; }
        //  public DbSet<Developer> Developers { get; set; } 
        public IQueryable<Person> GetPersonByAge(int age) => FromExpression(() => GetPersonByAge(age));
        public ApplicationDbContext()
        {
            //  Database.EnsureDeleted();
            //  Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDbFunction(() => GetPersonByAge(default));
             



            //Table name
            //modelBuilder.Entity<Person>().ToTable("Persons");
            //modelBuilder.Entity<Developer>().ToTable("Developers");
            //modelBuilder.Entity<Manager>().ToTable("Managers");
        }
    }
}
