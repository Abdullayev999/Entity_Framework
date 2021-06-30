using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TPH_and_TPT.Models;

namespace TPH_and_TPT
{
    class Program
    {
        static void Main(string[] args)
        {
            //TPH -> Table Per Hierarchy
            //TPT -> Table Per Type


            // FromSqlRaw
            // ExecuteSqlRaw


            //using var db = new ApplicationDbContext();

            //Department departament1 = new Department() { Name = "Web" };
            //Department departament2 = new Department() { Name = "Mobile" };
            //db.Departments.AddRange(departament1, departament2);

            //Person person1 = new Person() { Departament = departament1, FullName = "Abdullayev Farid", Age = 25, Salary = 200 };
            //Person person2 = new Person() { Departament = departament2, FullName = "Qurbanova  Ceyran", Age = 24, Salary = 1200 };
            //Person person3 = new Person() { Departament = departament2, FullName = "Abdullayev Cavid", Age = 28, Salary = 3200 };
            //Person person4 = new Person() { Departament = departament1, FullName = "Ivan Ivanov", Age = 21, Salary = 1700 };
            //Person person5 = new Person() { Departament = departament1, FullName = "Oleq Qazmanov", Age = 54, Salary = 2200 };
            //Person person6 = new Person() { Departament = departament1, FullName = "Dima Kapustin", Age = 18, Salary = 200 };
            //db.Persons.AddRange(person1, person2, person3, person4, person5, person6);

            //Manager manager1 = new Manager() { FullName = "Ivan Ivanov", Age = 34, Department = "StepIt", Salary = 4500 };
            //db.Managers.Add(manager1);

            //Developer developer1 = new Developer() { FullName = "Andrey Oleqov", Age = 28, Project = "Web", Position = "Middle", Salary = 4500 };
            //db.Developers.Add(developer1);


            //db.SaveChanges();

            //Console.WriteLine("---Persons : ");
            //foreach (var person in db.Persons)
            //{
            //    Console.WriteLine(person);
            //}
            //Console.WriteLine("\n-----------------\n");

            //Console.WriteLine("---Developers : ");
            //foreach (var developer in db.Developers)
            //{
            //    Console.WriteLine(developer);
            //}
            //Console.WriteLine("\n-----------------\n");

            //Console.WriteLine("---Managers : ");
            //foreach (var manager in db.Managers)
            //{
            //    Console.WriteLine(manager);
            //}
            //Console.WriteLine("\n-----------------\n");

            //using var db = new ApplicationDbContext();
            //var persons = db.Persons.FromSqlRaw("SELECT * FROM Persons ORDER BY Age");
            // var persons = db.Persons.FromSqlRaw("SELECT * FROM Persons").OrderBy(p=>p.Age);
            // var persons = db.Persons.FromSqlRaw("SELECT * FROM Persons WHERE Age>25");
            // var persons = db.Persons.FromSqlRaw("SELECT * FROM Persons").Where(p => p.Age > 25);

            // var persons = db.Persons.FromSqlRaw("SELECT * FROM Persons").Include(p=>p.Departament);

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //ADO NET var dbconnection = db.Database.GetDbConnection(); 
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            int age = 20;
            ////var persons = db.Persons.FromSqlRaw($"SELECT * FROM Persons WHERE Age>{age}");
            //var persons = db.Persons.FromSqlRaw($"SELECT * FROM Persons WHERE Age>{0}",age);


            //var paramAge = new SqlParameter("@age", age);
            //var persons = db.Persons.FromSqlRaw($"SELECT * FROM Persons WHERE Age>@age", paramAge);
            //foreach (var person in persons)
            //{
            //    Console.WriteLine(person);
            //}


            /////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////
            //EXECUTE SQL


            // using var db = new ApplicationDbContext();


            //using  var tranzaktion = db.Database.BeginTransaction();

            // try
            // {
            //     string name = "Natawa Durkova";
            //     int salary = 450;
            //     int departmentId = db.Departments.FirstOrDefault().Id;

            //     //INSERT
            //     //db.Database.ExecuteSqlRaw(@"INSERT INTO Persons (Salary,FullName,Age,DepartamentId)
            //     //                            VALUES ({0},{1},{2},{3})", salary,name,age,departmentId);



            //     int personId = 2;
            //     age = 99;
            //     salary = 999;

            //     //UPDATE
            //     //db.Database.ExecuteSqlRaw("UPDATE Persons SET Age = {0}, Salary = {1} WHERE Id = {2}", age, salary, personId);


            //     //DELETE
            //     db.Database.ExecuteSqlRaw("DELETE FROM Persons WHERE iD = {0}", personId);

            //     tranzaktion.Commit();
            // }
            // catch (Exception ex)
            // {
            //     tranzaktion.Rollback();
            //     Console.WriteLine(ex.Message);
            // }


            //var persons = db.Persons;
            // foreach (var person in persons)
            // {
            //     Console.WriteLine(person);
            // }



            ///////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////
            ///
            ///////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////
            ///
            // FUNCTION
            // FUNCTION
            // FUNCTION
            // FUNCTION


            //using var db = new ApplicationDbContext();
            //var paramAge  = new SqlParameter("@age", 25);
            //var persons = db.Persons.FromSqlRaw("SELECT * FROM GetPersonByAge(@age)", paramAge);

            //foreach (var person in persons)
            //{
            //    Console.WriteLine(person);
            //}

            //using var db = new ApplicationDbContext();
            //var persons  = db.GetPersonByAge(20);

            //foreach (var person in persons)
            //{
            //    Console.WriteLine(person);
            //}


            /////PROCEDURE
            /////PROCEDURE
            /////PROCEDURE
            /////PROCEDURE


            //using var db = new ApplicationDbContext();
            //var paramnAME  = new SqlParameter("@name", "Web");
            //var persons = db.Persons.FromSqlRaw("GetPersonByDepartment @name", paramnAME);

            //foreach (var person in persons)
            //{
            //    Console.WriteLine(person);
            //} 

        }
    }
}
