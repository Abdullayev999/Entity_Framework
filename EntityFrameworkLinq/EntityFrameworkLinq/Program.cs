using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new ApplicationDbContext();
            var itstep = db.Companies.FirstOrDefault();

            ////////////////////////////////////////////////////////
            //SELECT AND JOIN 
            ////////////////////////////////////////////////////////
            ///

            /*var persons = from person in db.Persons
                          where person.CompanyId == itstep.Id
                          select person;*/
            //OR
            /*var persons = db.Persons.Where(p => p.CompanyId == itstep.Id);*/

            //OR

            //var persons = db.Persons.Include(p=>p.Company).Where(p => p.CompanyId == itstep.Id);

            ///
            ////////////////////////////////////////////////////////
            //WHERE
            ////////////////////////////////////////////////////////
            ///

            // var persons = db.Persons.Where(p => p.Age > 23 && p.Age <=30);


            ///!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            ////////////////////////////////////////////////////////
            //SQL FUNCTION
            ////////////////////////////////////////////////////////
            ///!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


            // _ 1 symb
            //   % - mnoqo symbl
            //  [] - sootvetstvie simvolov
            //  [-] - sootvetsvie diapazonov simvolov 
            //  [^] - otsutsvie simvola 

            // var persons = db.Persons.Where(p => EF.Functions.Like(p.FullName, "%Abd%v"));
            // var persons = db.Persons.Where(p => EF.Functions.Like(p.FullName, "[a-f]%"));
            //   var persons = db.Persons.Where(p => EF.Functions.Like(p.FullName, "[^cf]%"));


            ///
            ////////////////////////////////////////////////////////
            //Find ( by key ) (PRIMARY KEY)
            ////////////////////////////////////////////////////////
            ///

            // var persons = db.Persons.Find(1);

            // Console.WriteLine(persons);



            ///
            ////////////////////////////////////////////////////////
            //SELECT
            ////////////////////////////////////////////////////////
            ///

            //var persons = db.Persons.Select(p => new {p.FullName });
            //Console.WriteLine($"-- {itstep.Name} staff : ");
            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item.FullName);
            //}

            //var persons = db.Persons.Select(p => new { Name = p.FullName.Substring(0,p.FullName.IndexOf(' ')),Surname = p.FullName.Substring(p.FullName.IndexOf(' ')+1,p.FullName.Length- p.FullName.IndexOf(' ') - 1), Age = p.Age });
            //Console.WriteLine($"-- {itstep.Name} staff : ");
            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item.Name + "\t" + item.Surname + "\t" + item.Age);
            //}



            ///
            ////////////////////////////////////////////////////////
            //ORDER BY (sortirovka po vozrastaniyu)
            ////////////////////////////////////////////////////////
            ///
            /// 

            //var persons = db.Persons.OrderBy(p => p.Age);
            //Console.WriteLine($"-- {itstep.Name} staff : ");
            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item);
            //}


            /// 
            ///
            ////////////////////////////////////////////////////////
            //ORDER ByDescending (sortirovka po ubivaniyu)
            ////////////////////////////////////////////////////////
            ///

            //var persons = db.Persons.OrderByDescending(p => p.Age);
            //Console.WriteLine($"-- {itstep.Name} staff : ");
            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item);
            //}


            //var persons = from person in db.Persons
            //              orderby person.Age
            //              select person;

            //Console.WriteLine($"-- {itstep.Name} staff : ");
            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item);
            //}


            ///
            ////////////////////////////////////////////////////////
            //ThenBy (POSLE ORDERBY esli 2 pole sortiruyem)
            ////////////////////////////////////////////////////////
            ///
            //var persons = db.Persons.OrderBy(p => p.Age).ThenBy(p=>p.Salary);
            //Console.WriteLine($"-- {itstep.Name} staff : ");
            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item);
            //}

            ///
            ////////////////////////////////////////////////////////
            //ThenBy ByDescending (POSLE ORDERBY esli 2 pole sortiruyem)
            ////////////////////////////////////////////////////////
            ///
            //var persons = db.Persons.OrderBy(p => p.Age).ThenByDescending(p => p.Salary);
            //Console.WriteLine($"-- {itstep.Name} staff : ");
            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item);
            //}

            ///
            ////////////////////////////////////////////////////////
            //GroupBy (grupirovka))
            ////////////////////////////////////////////////////////
            ///

            //var persons = from p in db.Persons
            //              group p by p.Company.Name
            //              into g
            //              select new {
            //                  Companiy = g.Key,
            //                  Count = g.Count()
            //              };



            //var persons = db.Persons.GroupBy(c => c.Company.Name).Select(g => new
            //{
            //    Companiy = g.Key,
            //    Count = g.Count()
            //});


            //Console.WriteLine($"-- {itstep.Name} staff : ");
            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item.Companiy+"\t"+item.Count);
            //}


            ///
            ////////////////////////////////////////////////////////
            // Join
            ////////////////////////////////////////////////////////
            ///

            //var persons = db.Persons.Join(db.Companies,p=>p.CompanyId,c=>c.Id,(p,c)=> new {p.FullName,p.Salary,p.Age,c.Name });

            //OR

            //var persons = from p in db.Persons
            //              join c in db.Companies on p.CompanyId equals c.Id
            //              select new  { p.FullName, p.Salary, p.Age, c.Name };

            //var persons = from person in db.Persons
            //              join companie in db.Companies on person.CompanyId equals companie.Id
            //              join country in db.Countries on companie.CountryId equals country.Id
            //              select new { person.FullName, person.Salary, person.Age, Companie  =companie.Name ,Country = country.Name};



            ///
            ////////////////////////////////////////////////////////
            // JOIN INCLUDE SQL ThenInclude
            ////////////////////////////////////////////////////////
            ///



            //var persons = db.Persons.Join(db.Companies, p => p.CompanyId, c => c.Id, (p, c) => new
            //{
            //    Person = p,
            //    Company = c
            //}).Join(db.Countries,t => t.Company.CountryId,country=>country.Id,
            //(pc,c)=>new
            //{
            //    pc.Person.FullName,
            //    pc.Person.Age,
            //    pc.Person.Salary,
            //    Company = pc.Company.Name,
            //    Country = c.Name
            //});

            //var persons = db.Persons.Include(c => c.Company).ThenInclude(c => c.Country);

            //Console.WriteLine($"-- {itstep.Name} staff : ");
            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item + "\t" + item.Company.Name + "\t" + item.Company.Country.Name);
            //}



            ///
            ////////////////////////////////////////////////////////
            // Union (Obyedinenie tablic)
            ////////////////////////////////////////////////////////
            ///

            //var persons = db.Persons.Where(p => p.Age <25).Union(db.Persons.Where(p => p.Salary < 1000));

            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item);
            //}

            ///
            ////////////////////////////////////////////////////////
            // Interesect (Peresecenie dannix)
            ////////////////////////////////////////////////////////
            ///

            //var persons = db.Persons.Where(p => p.Age < 25).Intersect(db.Persons.Where(p => p.Salary < 1000));

            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item);
            //}

            ///
            ////////////////////////////////////////////////////////
            // Except (Ne peresecennie dannix)
            ////////////////////////////////////////////////////////
            ///

            //var persons = db.Persons.Where(p => p.Age < 25).Except(db.Persons.Where(p => p.Salary < 1000));

            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item);
            //}

            ///
            ////////////////////////////////////////////////////////
            // Skip (propuskaet) 
            ////////////////////////////////////////////////////////
            ///

            //var persons = db.Persons.Skip(2);

            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item);
            //}

            ///
            ////////////////////////////////////////////////////////
            //  SkipLast (propuskaet s konca)
            ////////////////////////////////////////////////////////
            ///



            ///
            ////////////////////////////////////////////////////////
            // Take (vzyat kol dannix)
            ////////////////////////////////////////////////////////
            ///
            //var persons = db.Persons.Take(2);

            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item);
            //}


            ///
            ////////////////////////////////////////////////////////
            // TakeLast  (vzyat kol dannix)
            ////////////////////////////////////////////////////////
            ///



            ///
            ////////////////////////////////////////////////////////
            // ALL (ESLI VSE PODXODIT TO TRUE)
            ////////////////////////////////////////////////////////
            ///

            //var persons = db.Persons.All(p=>p.Age>0);

            //    Console.WriteLine(persons); 

            ///
            ////////////////////////////////////////////////////////
            // ANY (ESLI XOTYABI 1 PODXODIT TO TRUE)
            ////////////////////////////////////////////////////////
            ///

            //var persons = db.Persons.Any(p => p.Age > 0);

            //Console.WriteLine(persons);

            ///
            ////////////////////////////////////////////////////////
            // CONTAINS (Proveryayet suwestvuet li danie)
            ////////////////////////////////////////////////////////
            ///



            ///
            ////////////////////////////////////////////////////////
            // First vernet 1 obyekt ili je null esli pustaya db
            ////////////////////////////////////////////////////////
            ///
            //var person = db.Persons.First();

            //    Console.WriteLine(person); 


            ///
            ////////////////////////////////////////////////////////
            // FirstOrDefault vozrawaet 1iy obyekt ili default znacnie (ref-null,value-0);
            ////////////////////////////////////////////////////////
            ///

            //var person = db.Persons.FirstOrDefault();

            //Console.WriteLine(person);



            ///
            ////////////////////////////////////////////////////////
            // ToList
            ////////////////////////////////////////////////////////
            ///

            //var persons = db.Persons.ToList();

            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item);
            //};



            ///
            ////////////////////////////////////////////////////////
            // Min
            ////////////////////////////////////////////////////////
            ///

            // var person = db.Persons.Min(p => p.Age); 

            //Console.WriteLine(person);

            ////////////////////////////////////////////////////////
            // Sum
            ////////////////////////////////////////////////////////
            ///

            //var person = db.Persons.Sum(p => p.Age);

            //Console.WriteLine(person);


            ///
            ////////////////////////////////////////////////////////
            // AVG
            ////////////////////////////////////////////////////////
            ///


            //var person = db.Persons.Average(p => p.Age);

            //Console.WriteLine(person);

            ///
            ////////////////////////////////////////////////////////
            // MAX
            ////////////////////////////////////////////////////////
            ///


            //var person = db.Persons.Max(p => p.Age);

            //Console.WriteLine(person);

            ///
            ////////////////////////////////////////////////////////
            //COUNT
            ////////////////////////////////////////////////////////
            ///

            //var person = db.Persons.Count(p => p.Age==25);

            //Console.WriteLine(person);


        }
    }
}
