using EntityFrameworkLinq.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLinq
{ 
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public ApplicationDbContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

            //Country ukraine = new Country() { Name = "Ukraine" };
            //Country usa = new Country() { Name = "USA" };
            //this.Countries.AddRange(ukraine, usa);


            //Company itstep = new Company() { Name = "ItStep" ,Country = ukraine };
            //Company microsoft = new Company() { Name = "Microsoft",Country =usa };

            //this.Companies.AddRange(itstep, microsoft);

            //Person person1 = new Person() { FullName = "Farid Abdullayev", Salary = 2200, Age = 25, Company = itstep };
            //Person person2 = new Person() { FullName = "Nikita Cerkasov", Salary = 1200, Age = 25, Company = itstep };
            //Person person3 = new Person() { FullName = "Artem Qutsol", Salary = 7200, Age = 25, Company = microsoft };
            //Person person4 = new Person() { FullName = "Olqa Oleqovna", Salary = 9200, Age = 25, Company = microsoft };
            //Person person5 = new Person() { FullName = "Cavid Abdullayev", Salary = 3700, Age = 28, Company = microsoft };
            //Person person6 = new Person() { FullName = "Ceyran Qurbanova", Salary = 1300, Age = 24, Company = itstep };
            //Person person7 = new Person() { FullName = "Ivan Ivanov", Salary = 700, Age = 19, Company = itstep };

            //this.Persons.AddRange(person1, person2, person3, person4, person5, person6, person7);

            //this.SaveChanges();

        } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TmpDB;");
        }
    }
}
