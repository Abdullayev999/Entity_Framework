using CodeFirstСommunications.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CodeFirstСommunications
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new ApplicationDBContext();
            //default EF CASCADE
            // int? NameId == SET NULL
            // int NameId == CASCADE

            ////1-1
            //Person person1 = new Person { Fullname = "Ivan Ivanov", BirthDate = DateTime.Now };
            //Account account1 = new Account { Login = "Ivanok", Password = "12345678", UserName = "Ivan225" };
            //account1.Person = person1;
            //person1.Account = account1;
            //db.Persons.Add(person1);
            //db.Accounts.Add(account1);
            //db.SaveChanges();

            ///////////////////////////////////////////////

            //Brand brand1 = new Brand { Name = "Toyota" };
            //Automobile automobile1 = new Automobile { Model = "Camry", Price = 21000 };
            //Automobile automobile2 = new Automobile { Model = "Corolla", Price = 26000 };
            //brand1.Automobiles = new List<Automobile>();
            //brand1.Automobiles.Add(automobile1);
            //brand1.Automobiles.Add(automobile2);
            //automobile1.Brand = brand1;
            //automobile2.Brand = brand1;
            //db.Brands.Add(brand1);
            //db.Automobiles.AddRange(automobile1, automobile2);
            //db.SaveChanges();


            //var brand1 = db.Brands.FirstOrDefault();
            //Automobile automobile3 = new Automobile { Model = "Prius", Price = 14000 };
            //automobile3.Brand = brand1;
            //db.Automobiles.Add(automobile3);
            //db.SaveChanges();

            //var brand1 = db.Brands.FirstOrDefault();
            //db.Brands.Remove(brand1);
            //db.SaveChanges();


            ////////////////////////////////////////////

            //Product product1 = new Product { Name = "Замороженное мясо", Price = 10 };
            //Product product2 = new Product { Name = "Креветки", Price = 10 };

            //Category category1 = new Category { Name = "Замороженное" };
            //Category category2 = new Category { Name = "Мясное" };
            //Category category3 = new Category { Name = "Морепродукт" };

            //product1.Categories = new List<Category>();
            //product1.Categories.Add(category1);
            //product1.Categories.Add(category2);

            //product2.Categories = new List<Category>();
            //product2.Categories.Add(category1);
            //product2.Categories.Add(category3);

            //category1.Products = new List<Product>();
            //category1.Products.Add(product1);
            //category1.Products.Add(product2);

            //category2.Products = new List<Product>();
            //category2.Products.Add(product1);

            //category3.Products = new List<Product>();
            //category3.Products.Add(product2);

            //db.Categories.AddRange(category1, category2, category3);
            //db.Products.AddRange(product1, product2);

            //db.SaveChanges();

            ////////////////////////////////////////////

            // Include -> eager loading
            //db.Products.Include(p => p.Categories).ToList();

            //foreach (var product in db.Products)
            //{
            //    Console.Write($"Product: {product.Name} {product.Price}$");
            //    Console.Write(" Categories: ");
            //    foreach (var category in product.Categories)
            //    {
            //        Console.Write($"{category.Name}; ");
            //    }
            //    Console.WriteLine();
            //}  

            //var products = db.Products.FirstOrDefault();

            ////////////////////////////////////////////

            // Load -> explicit loading
            //PODQRUZKA 1
            //var auto1 = db.Automobiles.FirstOrDefault();
            //db.Brands.Where(b => b.Id == auto1.BrandId).Load();
            //var brand1 = db.Brands.FirstOrDefault();

            //PODQRUZKA MNOQO
            //var brand1 = db.Brands.FirstOrDefault();
            //db.Entry(brand1).Collection(b => b.Automobiles).Load();

            ////  Console.WriteLine(brand1.Name);
            //foreach (var auto in brand1.Automobiles)
            //{
            //    Console.WriteLine(auto.Model);
            //}

            ///////////////////////////////////////////


            // Lazy loading
            var products = db.Products.ToList();
            foreach (var product in products)
            {
                Console.Write($"Product: {product.Name} {product.Price}$");
                Console.Write(" Categories: ");
                foreach (var category in product.Categories)
                {
                    Console.Write($"{category.Name}; ");
                }
                Console.WriteLine();
            }

            //foreach (var product in db.Products)
            //{
            //    Console.Write($"Product: {product.Name} {product.Price}$");
            //    Console.Write(" Categories: ");
            //    foreach (var category in product.Categories)
            //    {
            //        Console.Write($"{category.Name}; ");
            //    }
            //    Console.WriteLine();
            //}

        }
    }
}
