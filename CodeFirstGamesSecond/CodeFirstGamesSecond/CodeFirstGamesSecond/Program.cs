using CodeFirstGamesSecond.Models;
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
            DBFill(db);

            db.Games.Include(f => f.Firma).ThenInclude(c => c.Country);
            db.Games.Include(s => s.Style);

            do
            {

                Console.WriteLine("\n1  - Отображение количества однопользовательских игр"
                                + "\n2  - Отображение количества многопользовательских игр"
                                + "\n3  - Показать игру с максимальным количеством проданных игр конкретного стиля"
                                + "\n4  - Отображение топ - 5 самых продаваемых игр конкретного стиля"
                                + "\n5  - Отображение топ - 5 самых непродаваемых игр конкретного стиля"
                                + "\n6  - Отобразить полную информацию об игре"
                                + "\n7  - Отобразить название каждой студии и стиль, по которому у студии максимальное количество игр"
                                + "\n8  - Добавление новой студии. Перед добавлением нужно проверить не существует ли уже такая студия"
                                + "\n9 -  Изменение данных существующей студии. Пользователь может изменить любой параметр студии"
                                + "\n10 - Удаление студии. Поиск удаляемой студии производится по названию студии."
                                + "\n11 - Выход\n");


                int.TryParse(Console.ReadLine(), out int action);
                Console.Clear();
                if (action == 1)
                {

                    var counts = db.Games.Where(i => i.IsMultiplayer.Equals("no")).Count();

                    Console.WriteLine("Single player game quantity : " + counts);
                }
                else if (action == 2)
                {
                    var counts = db.Games.Where(i => i.IsMultiplayer.Equals("yes")).Count();

                    Console.WriteLine("Single player game quantity : " + counts);
                }
                else if (action == 3)
                {
                    Console.Write("Enter Game Style : ");
                    string gameStyle = Console.ReadLine();


                    var items = db.Sales.Where(i => (i.Game.Style.Name.Equals(gameStyle))).GroupBy(i => i.Game.Name).Select(g => new
                    {
                        Name = g.Key,
                        SalesCount = g.Sum(i => i.Quantity)
                    }).OrderByDescending(g => g.SalesCount).Take(1);

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.SalesCount);
                        }
                    }

                }
                else if (action == 4)
                {
                    Console.Write("Enter Game Style : ");
                    string gameStyle = Console.ReadLine();


                    var items = db.Sales.Where(i => (i.Game.Style.Name.Equals(gameStyle))).GroupBy(i => i.Game.Name).Select(g => new
                    {
                        Name = g.Key,
                        SalesCount = g.Sum(i => i.Quantity)
                    }).OrderByDescending(g => g.SalesCount).Take(5);

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.SalesCount);
                        }
                    }
                }
                else if (action == 5)
                {
                    Console.Write("Enter Game Style : ");
                    string gameStyle = Console.ReadLine();


                    var items = db.Sales.Where(i => (i.Game.Style.Name.Equals(gameStyle))).GroupBy(i => i.Game.Name).Select(g => new
                    {
                        Name = g.Key,
                        SalesCount = g.Sum(i => i.Quantity)
                    }).OrderBy(g => g.SalesCount).Take(5);

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.SalesCount);
                        }
                    }
                }
                else if (action == 6)
                {
                    Console.Write("Enter game Name : ");
                    var gameName = Console.ReadLine();

                    var item = db.Games.Where(i => i.Name.Equals(gameName)).FirstOrDefault(); ;

                    if (item == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        Console.WriteLine(item.Name.PadRight(19, ' ') + item.Style.Name.PadRight(19, ' ') + item.Firma.Name.PadRight(19, ' ') + item.Firma.Country.Name.PadRight(19, ' ') + item.ReleaseDate.ToShortDateString().PadRight(19, ' ') + item.IsMultiplayer.PadRight(5, ' '));

                    }
                }
                else if (action == 7)
                {
                    var item = db.Games.GroupBy(i => new { Firma = i.Firma.Name, Style = i.Style.Name }).Select(g => new
                    {
                        Firma = g.Key.Firma,
                        Style = g.Key.Style,
                        CountGame = g.Count()
                    }).OrderByDescending(i => i.CountGame).FirstOrDefault();

                    if (item == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        Console.WriteLine(item.Firma.PadRight(19, ' ') + item.Style.PadRight(19, ' ') + item.CountGame);
                    }
                }
                else if (action == 8)
                {
                    Console.Write("Enter Name : ");
                    string name = Console.ReadLine();

                    var item = db.Firms.Where(i => i.Name == name).FirstOrDefault();

                    if (item == null || !item.Name.Equals(name))
                    {

                        foreach (var country in db.Countries)
                        {
                            Console.WriteLine(country.Id + " " + country.Name);
                        }
                        Console.Write("Enter   Country Id : ");
                        Country country1;
                        do
                        {
                            int.TryParse(Console.ReadLine(), out int id);

                            country1 = db.Countries.Where(i => i.Id == id).FirstOrDefault();

                            if (country1 != null)
                            {
                                break;
                            }
                        } while (true);



                        db.Firms.Add(new Firma() { Name = name, Country = country1 });
                        db.SaveChanges();
                        Console.WriteLine("Added successfully");

                    }
                    else
                    {
                        Console.WriteLine("This game exists");
                    }
                }
                else if (action == 9)
                {
                    foreach (var item in db.Firms)
                    {
                        Console.WriteLine(item.Id.ToString().PadRight(3, ' ') + item.Name.PadRight(19, ' '));
                    }
                    Console.Write("\n\nSelect id : ");
                    int.TryParse(Console.ReadLine(), out int id);

                    var firms = db.Firms.Where(i => i.Id == id).FirstOrDefault();

                    if (firms == null)
                    {
                        Console.WriteLine("Incorrect select");
                    }
                    else
                    {

                        Console.Write("\n\n1 - Name\n2 - Country\nSelect change index  : ");
                        int.TryParse(Console.ReadLine(), out int index);

                        switch (index)
                        {
                            case 1:
                                Console.Write("Enter Name : ");
                                string name = Console.ReadLine();

                                firms.Name = Console.ReadLine();
                                break;
                            case 2:
                                foreach (var country in db.Countries)
                                {
                                    Console.WriteLine(country.Id + " " + country.Name);
                                }
                                Console.Write("Enter Country Id : ");
                                Country country1;
                                do
                                {
                                    int.TryParse(Console.ReadLine(), out int idCountry);

                                    country1 = db.Countries.Where(i => i.Id == idCountry).FirstOrDefault();

                                    if (country1 != null)
                                    {
                                        break;
                                    }
                                } while (true);

                                firms.Country = country1;
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("Change Saved");
                        db.SaveChanges();
                    }
                }
                else if (action == 10)
                {
                    try
                    {
                        Console.Write("Enter firms  Name for delete : ");
                        string name = Console.ReadLine();

                        var item = db.Firms.Where(x => x.Name == name).FirstOrDefault();
                        if (item != null && item.Name == name)
                        {
                            Console.WriteLine("Delete firm?\n1 - Yes\n2 - No");
                            int.TryParse(Console.ReadLine(), out int index);
                            if (index == 1)
                            {
                                var firmsCount = db.Firms.Count();
                                db.Firms.Remove(item);
                                db.SaveChanges();
                                var newFirmsCount = db.Firms.Count();
                                if (firmsCount > newFirmsCount)
                                {

                                    Console.WriteLine("Delete complited");
                                }
                                else Console.WriteLine("The deletion did not happen");
                            }
                            else Console.WriteLine("The deletion did not happen");
                        }
                        else Console.WriteLine("The deletion did not happen");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (action == 11)
                {
                    return;
                }

                Console.ReadKey();

                Console.Clear();
            } while (true);



            //Добавьте возможность добавления, удаления всех данных об играх.

            // ADD Country
            var countr = new Country() { Name = "Azerbaijan" };

            // ADD Firma
            var firm = new Firma() { Name = "Tesla", Country = countr };

            // ADD Style
            var style = new Style() { Name = "Fun" };

            // ADD Game
            var game = new Game() { Name = "Tom and Jerry", ReleaseDate = DateTime.Now, Firma = firm, Style = style, IsMultiplayer = "no" };



            // Delete Country 
            db.Countries.Remove(db.Countries.First());

            // Delete Firma
            db.Firms.Remove(db.Firms.First());

            // Delete Style
            db.Styles.Remove(db.Styles.First());

            // Delete Game
            db.Games.Remove(db.Games.First());

            db.SaveChanges();
        }
    }
}
