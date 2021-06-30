using CodeFirstGamesSecond.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstGamesSecond
{
    class Program
    { 
        public static void DBFill(ApplicationContextDB db)
        {
            List<Country> countries = new List<Country>()
            {
                new Country { Name = "USA" },
                new Country { Name = "Germany" },
                new Country { Name = "China" }
             };

            List<Style> styles = new List<Style>()
            {
                new Style { Name = "Simulation" },
                new Style { Name = "Strategy" },
                new Style { Name = "Sport" }
             };

            List<Firma> firms = new List<Firma>()
            {
               new Firma { Name = "Konami" , Country = countries[0] },
               new Firma { Name = "Electronic Arts",Country = countries[1] },
               new Firma { Name = "Bandai Namco",Country = countries[2] }
            };

            List<Game> games = new List<Game>()
            {
                new Game { Name = "World of Tank", ReleaseDate = DateTime.Parse("2012-10-10"), Style = styles[1], Firma = firms[1], IsMultiplayer = "yes" },
                new Game { Name = "Tarzan", ReleaseDate = DateTime.Parse("2008-01-01"), Style = styles[0], Firma = firms[2], IsMultiplayer = "no" },
                new Game { Name = "Pes2015", ReleaseDate = DateTime.Parse("2015-08-11"), Style = styles[2], Firma = firms[0], IsMultiplayer = "yes" },
                new Game { Name = "Spider Man", ReleaseDate = DateTime.Parse("2004-07-02"), Style = styles[0], Firma = firms[1], IsMultiplayer = "no" },
                new Game { Name = "Mario", ReleaseDate = DateTime.Parse("2000-02-08"), Style =  styles[0], Firma = firms[2], IsMultiplayer = "no" },
                new Game { Name = "Need for Speed", ReleaseDate = DateTime.Parse("2007-09-10"), Style = styles[2], Firma = firms[1], IsMultiplayer = "yes" },
                new Game { Name = "Hulk", ReleaseDate = DateTime.Parse("2005-06-01"), Style =  styles[0], Firma = firms[0], IsMultiplayer = "no" }
            };

            List<Sale> sales = new List<Sale>()
            {
               new Sale() { Game = games[1], Quantity = 1 },
               new Sale() { Game = games[2], Quantity = 10 },
               new Sale() { Game = games[3], Quantity = 12 },
               new Sale() { Game = games[4], Quantity = 15 },
               new Sale() { Game = games[5], Quantity = 33 },
               new Sale() { Game = games[6], Quantity = 12 },
               new Sale() { Game = games[0], Quantity = 2 },
               new Sale() { Game = games[1], Quantity = 3 },
               new Sale() { Game = games[2], Quantity = 1 },
               new Sale() { Game = games[3], Quantity = 2 },
               new Sale() { Game = games[4], Quantity = 3 },
               new Sale() { Game = games[5], Quantity = 4 },
               new Sale() { Game = games[6], Quantity = 5 },
               new Sale() { Game = games[0], Quantity = 3 },
               new Sale() { Game = games[1], Quantity = 4 },
               new Sale() { Game = games[2], Quantity = 6 },
               new Sale() { Game = games[3], Quantity = 5 },
               new Sale() { Game = games[4], Quantity = 7 },
               new Sale() { Game = games[5], Quantity = 8 },
               new Sale() { Game = games[6], Quantity = 9 },
               new Sale() { Game = games[0], Quantity = 10 }
            };


            db.Styles.AddRange(styles);
            db.Firms.AddRange(firms);
            db.Games.AddRange(games);
            db.Sales.AddRange(sales);
            db.SaveChanges();
        }

        static void Main(string[] args)
        {
            using var db = new ApplicationContextDB();
           // DBFill(db);

            db.Games.Include(f => f.Firma).ThenInclude(c => c.Country);
            db.Games.Include(s => s.Style);

            do
            {

                Console.WriteLine("\n1  - Показать топ-3 студий с максимальным количеством игр"
                                + "\n2  - Показать студию с максимальным количеством игр"
                                + "\n3  - Показать топ-3 самых популярных стилей по количеству игр"
                                + "\n4  - Показать самый популярный стиль по количеству игр"
                                + "\n5  - Показать топ-3 самых популярных стилей по количеству продаж"
                                + "\n6  - Показать самый популярный стиль по количеству продаж"
                                + "\n7  - Показать топ-3 самых популярных однопользовательских игр по количеству продаж"
                                + "\n8  - Показать топ-3 самых популярных многопользовательских игр по количеству продаж"
                                + "\n9 -  Показать самую популярную однопользовательскую игру по количеству продаж"
                                + "\n10 - Показать самую популярную многопользовательскую игру по количеству продаж"
                                + "\n11 - Показать самую популярную игру по количеству продаж"
                                + "\n12 - Выход\n");


                int.TryParse(Console.ReadLine(), out int action);
                Console.Clear();
                if (action == 1)
                {
                    //Method 1
                    //var results = db.Games.GroupBy(g => g.Firma.Name).Select((g) => new
                    //{
                    //    Firma = g.Key,
                    //    Count = g.Count()
                    //}).OrderByDescending(g=>g.Count).Take(3);


                    //Method 2
                    // Default top 3
                    var results = db.TopFirmsByMaxCountGame();//db.TopFirmsByMaxCountGame(any number);

                    if (results == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in results)
                        {
                           Console.WriteLine(item.Name.PadRight(18,' ')+item.Count);
                        }
                    }


                }
                else if (action == 2)
                {
                    //Method 1
                    //var results = db.Games.GroupBy(g => g.Firma.Name).Select((g) => new
                    //{
                    //    Firma = g.Key,
                    //    Count = g.Count()
                    //}).OrderByDescending(g => g.Count).Take(1);


                    //Method 2
                    var results = db.MaxFimaByCounGame();

                    if (results == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in results)
                        {
                            Console.WriteLine(item.Name.PadRight(18, ' ') + item.Count);
                        }
                    }
                }
                else if (action == 3)
                {
                    //Method 1
                    //var results = db.Games.GroupBy(g => g.Style.Name).Select((g) => new
                    //{
                    //    Name = g.Key,
                    //    Count = g.Count()
                    //}).OrderByDescending(g => g.Count).Take(3);


                    //Method 2
                    var results = db.TopStyleByMaxCountGame();

                    if (results == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in results)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Count);
                        }
                    }
                }
                else if (action == 4)
                {
                    //Method 1
                    //var results = db.Games.GroupBy(g => g.Style.Name).Select((g) => new
                    //{
                    //    Name = g.Key,
                    //    Count = g.Count()
                    //}).OrderByDescending(g => g.Count).Take(1);


                    //Method 2
                    var results = db.PopulationStyleByCountGame();
                    if (results == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in results)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Count);
                        }
                    }
                }
                else if (action == 5)
                {
                    //Method 1
                    //var results = db.Sales.GroupBy(g => g.Game.Style.Name).Select((g) => new
                    //{
                    //    Name = g.Key,
                    //    Count = g.Sum(g => g.Quantity)
                    //}).OrderByDescending(g => g.Count).Take(3);


                    //Method 2
                    var results = db.TopStyleBySalesCountGame();
                    if (results == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in results)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Count);
                        }
                    }
                }
                else if (action == 6)
                {
                    //Method 1
                    //var results = db.Sales.GroupBy(g => g.Game.Style.Name).Select((g) => new
                    //{
                    //    Name = g.Key,
                    //    Count = g.Sum(g => g.Quantity)
                    //}).OrderByDescending(g => g.Count).Select((g)=>g.Name).Take(1);


                    //Method 2
                    var results = db.PopulationStyleBySalesGame();
                    if (results == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in results)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Count);
                        }
                    }
                }
                else if (action == 7)
                {
                    //Method 1
                    //var results = db.Sales.Where(g=>g.Game.IsMultiplayer.Equals("no")).GroupBy(g => g.Game.Name).Select((g) => new
                    //{
                    //    Name = g.Key,
                    //    Count = g.Sum(g => g.Quantity)
                    //}).OrderByDescending(g => g.Count).Take(3);


                    //Method 2
                    var results = db.TopGameByNotMultiplayerByCountSales();
                    if (results == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in results)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Count);
                        }
                    }
                }
                else if (action == 8)
                {
                    //Method 1
                    //var results = db.Sales.Where(g => g.Game.IsMultiplayer.Equals("yes")).GroupBy(g => g.Game.Name).Select((g) => new
                    //{
                    //    Name = g.Key,
                    //    Count = g.Sum(g => g.Quantity)
                    //}).OrderByDescending(g => g.Count).Take(3);


                    //Method 2
                    var results = db.TopGameByMultiplayerByCountSales();
                    if (results == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in results)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Count);
                        }
                    }
                }
                else if (action == 9)
                {
                    //Method 1
                    //var results = db.Sales.Where(g => g.Game.IsMultiplayer.Equals("no")).GroupBy(g => g.Game.Name).Select((g) => new
                    //{
                    //    Name = g.Key,
                    //    Count = g.Sum(g => g.Quantity)
                    //}).OrderByDescending(g => g.Count).Select((g)=> g.Game).Take(1);


                    //Method 2
                    var results = db.PopulationGameByNotMultiplayerByCountSales();

                    if (results == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in results)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Count);
                        }
                    }
                }
                else if (action == 10)
                {
                    //Method 1
                    //var results = db.Sales.Where(g => g.Game.IsMultiplayer.Equals("yes")).GroupBy(g => g.Game.Name).Select((g) => new
                    //{
                    //    Name = g.Key,
                    //    Count = g.Sum(g => g.Quantity)
                    //}).OrderByDescending(g => g.Count).Select((g) => g.Game).Take(1);


                    //Method 2
                    var results = db.PopulationGameByMultiplayerByCountSales();
                    if (results == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in results)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Count);
                        }
                    }
                }
                else if (action == 11)
                {
                    //Method 1
                    //var results = db.Sales.GroupBy(g => g.Game.Name).Select((g) => new
                    //{
                    //    Name = g.Key,
                    //    Count = g.Sum(g => g.Quantity)
                    //}).OrderByDescending(g => g.Count).Select((g) => g.Game).Take(1);


                    //Method 2
                    var results = db.PopulationGamByCountSales();
                    if (results == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in results)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Count);
                        }
                    }

                }
                else if (action == 12)
                {
                    return;
                }

                Console.ReadKey();

                Console.Clear();
            } while (true);



            
            //Задание 2.Добавьте новую функциональность к проекту об играх: 
            //-Напишите процедуру, которая удаляет все игры с количеством продаж равным нулю;
            //-Напишите процедуру, которая удаляет все игры с количеством продаж равным параметру, переданному в процедуру

            //1
            db.Games.FromSqlRaw("DeleteByZeroGame");

            //2 
            var paramCount = new SqlParameter("@count", 5);
            db.Games.FromSqlRaw("DeleteByCount @count", paramCount);
        }
    }
}
