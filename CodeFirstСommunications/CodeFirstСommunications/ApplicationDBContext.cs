using CodeFirstСommunications.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstСommunications
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Automobile> Automobiles { get; set; }
        public ApplicationDBContext()
        {
            //this.Database.EnsureDeleted();
           // this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        //Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Account>()
            //             .HasOne(a => a.Person)
            //             .WithOne(p => p.Account)
            //             .HasForeignKey<Account>(x => x.PersonId);



            //modelBuilder.Entity<Automobile>()
            //             .HasOne(a => a.Brand)
            //             .WithMany(b => b.Automobiles)
            //             .HasForeignKey(a => a.BrandId)
            //             .OnDelete(DeleteBehavior.Cascade);


            //Restrict = posle udalenie ne izmenit id
            //No action == udalenie zapriwaet
            //set null = pri udaleni zamenyayet na null
            // cascade pri udalenie udalyayet vse
             

            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Products)
                        .WithMany(p => p.Categories);
        }
    }
}
