using CodeFirstGames.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstGames
{
    class Program
    {

        public static void DBFill(ApplicationContextDB db)
        {
            List<Style> styles = new List<Style>()
            {
                new Style { Name = "Simulation" },
                new Style { Name = "Strategy" },
                new Style { Name = "Sport" } 
             }; 
            List<Firma> firms = new List<Firma>()
            {
                new Firma { Name = "Konami" },
                new Firma { Name = "Electronic Arts" },
                new Firma { Name = "Bandai Namco" }
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
            db.Games.Include(f => f.Firma);
            db.Games.Include(s => s.Style);

            do
            {

                Console.WriteLine("\n1  - Поиск информации по названию игры"
                                + "\n2  - Поиск игр по названию студии (фирму)"
                                + "\n3  - Поиск информации по названию студии и игры"
                                + "\n4  - Поиск игр по стилю"
                                + "\n5  - Поиск игр по году релиза"
                                + "\n6  - Отображение информации обо всех однопользовательских играх"
                                + "\n7  - Отображение информации обо всех многопользовательских играх"
                                + "\n8  - Показать игру с максимальным количеством проданных иг"
                                + "\n9 - Показать игру с минимальным количеством проданных игр"
                                + "\n10 - Отображение топ-3 самых продаваемых игр"
                                + "\n11 - Отображение топ-3 самых непродаваемых игр"
                                + "\n12 - Добавление новой игры. Перед добавлением нужно проверить не существует ли уже такая игра"
                                + "\n13 - Изменение данных существующей игры. Пользователь может изменить любой параметр игры"
                                + "\n14 - Удаление игры. Поиск удаляемой игры производится по названию игры и студии. Перед удалением игры приложение должно спросить пользователя нужно ли удалять игру"
                                + "\n15 - Выход\n");


                int.TryParse(Console.ReadLine(), out int action);
                Console.Clear();
                if (action == 1)
                {
                    Console.Write("Enter Game Name : ");
                    string gameName = Console.ReadLine();

                    var items = db.Games.Where(i => i.Name.Equals(gameName));

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Style.Name.PadRight(19, ' ') + item.Firma.Name.PadRight(19, ' ') + item.ReleaseDate.ToShortDateString().PadRight(19, ' ') + item.IsMultiplayer.PadRight(5, ' '));
                        }
                    }
                }
                else if (action == 2)
                {
                    Console.Write("Enter Game Firm : ");
                    string firmaName = Console.ReadLine();

                    var items = db.Games.Where(i => i.Firma.Name.Equals(firmaName));

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Style.Name.PadRight(19, ' ') + item.Firma.Name.PadRight(19, ' ') + item.ReleaseDate.ToShortDateString().PadRight(19, ' ') + item.IsMultiplayer.PadRight(5, ' '));
                        }
                    }
                }
                else if (action == 3)
                {
                    Console.Write("Enter Game Name : ");
                    string gameName = Console.ReadLine();

                    Console.Write("Enter Game Firma : ");
                    string firmaName = Console.ReadLine();


                    var items = db.Games.Where(i => (i.Name.Equals(gameName) && i.Firma.Name.Equals(firmaName)));

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Style.Name.PadRight(19, ' ') + item.Firma.Name.PadRight(19, ' ') + item.ReleaseDate.ToShortDateString().PadRight(19, ' ') + item.IsMultiplayer.PadRight(5, ' '));
                        }
                    }
                }
                else if (action == 4)
                {
                    Console.Write("Enter Game Style : ");
                    string gameStyle = Console.ReadLine();

                    var items = db.Games.Where(i => i.Style.Name.Equals(gameStyle));

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Style.Name.PadRight(19, ' ') + item.Firma.Name.PadRight(19, ' ') + item.ReleaseDate.ToShortDateString().PadRight(19, ' ') + item.IsMultiplayer.PadRight(5, ' '));
                        }
                    }
                }
                else if (action == 5)
                {
                    Console.Write("Enter Game Relase : ");
                    DateTime.TryParse(Console.ReadLine(), out DateTime releaseDate);

                    var items = db.Games.Where(i => i.ReleaseDate.Equals(releaseDate));

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Style.Name.PadRight(19, ' ') + item.Firma.Name.PadRight(19, ' ') + item.ReleaseDate.ToShortDateString().PadRight(19, ' ') + item.IsMultiplayer.PadRight(5, ' '));
                        }
                    }
                }
                else if (action == 6)
                {
                    var items = db.Games.Where(i => i.IsMultiplayer.Equals("no"));

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Style.Name.PadRight(19, ' ') + item.Firma.Name.PadRight(19, ' ') + item.ReleaseDate.ToShortDateString().PadRight(19, ' ') + item.IsMultiplayer.PadRight(5, ' '));
                        }
                    }
                }
                else if (action == 7)
                {
                    var items = db.Games.Where(i => i.IsMultiplayer.Equals("yes"));

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Style.Name.PadRight(19, ' ') + item.Firma.Name.PadRight(19, ' ') + item.ReleaseDate.ToShortDateString().PadRight(19, ' ') + item.IsMultiplayer.PadRight(5, ' '));
                        }
                    }
                }
                else if (action == 8)
                {
                    var items = db.Sales.GroupBy(s => s.Game.Name).Select(g => new
                    {
                        name = g.Key,
                        count = g.Sum(x => x.Quantity)
                    }).OrderByDescending(i => i.count).Take(1);

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.name.PadRight(19, ' ') + item.count.ToString().PadRight(19, ' '));
                        }
                    }

                }
                else if (action == 9)
                {
                    var items = db.Sales.GroupBy(s => s.Game.Name).Select(g => new
                    {
                        name = g.Key,
                        count = g.Sum(x => x.Quantity)
                    }).OrderBy(i => i.count).Take(1);

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.name.PadRight(19, ' ') + item.count.ToString().PadRight(19, ' '));
                        }
                    }
                }
                else if (action == 10)
                {
                    var items = db.Sales.GroupBy(s => s.Game.Name).Select(g => new
                    {
                        Name = g.Key,
                        Count = g.Sum(i => i.Quantity)
                    }).OrderByDescending(i => i.Count).Take(3);

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Count.ToString().PadRight(19, ' '));
                        }
                    }
                }
                else if (action == 11)
                {
                    var items = db.Sales.GroupBy(s => s.Game.Name).Select(g => new
                    {
                        Name = g.Key,
                        Count = g.Sum(i => i.Quantity)
                    }).OrderBy(i => i.Count).Take(3);

                    if (items == null)
                    {
                        Console.WriteLine("Not Game");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.Name.PadRight(19, ' ') + item.Count.ToString().PadRight(19, ' '));
                        }
                    }
                }
                else if (action == 12)
                {
                    Console.Write("Enter Name : ");
                    string name = Console.ReadLine();

                    var item = db.Games.Where(i => i.Name.Equals(name)).Select(item => item.Name);

                    if (item.Equals(name))
                    {
                        Console.Write("Enter ReleaseDate : ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime time);

                        Console.Write("Enter Firma Name : ");
                        string firmaName = Console.ReadLine();
                        var firm = db.Firms.Where(i => i.Name.Equals(firmaName)).First();

                        Console.Write("Enter Style Name : ");
                        string styleName = Console.ReadLine();
                        var style = db.Styles.Where(i => i.Name.Equals(styleName)).First();

                         

                        Console.Write("Enter Multiple (yes/no) ");
                        var multi = Console.ReadLine();

                        if (!multi.Equals("yes")) multi = "no";


                        db.Games.Add(new Game() { Name = name, Firma = firm, Style = style, ReleaseDate = time, IsMultiplayer = multi });
                        db.SaveChanges();
                        Console.WriteLine("Added successfully");

                    }
                    else
                    {
                        Console.WriteLine("This game exists");
                    }
                }
                else if (action == 13)
                {
                    foreach (var item in db.Games)
                    {
                        Console.WriteLine(item.Id.ToString().PadRight(3, ' ') + item.Name.PadRight(19, ' ') + item.Style.Name.PadRight(19, ' ') + item.Firma.Name.PadRight(19, ' ') + item.ReleaseDate.ToShortDateString().PadRight(19, ' ') + item.IsMultiplayer.PadRight(5, ' '));
                    }
                    Console.Write("\n\nSelect id : ");
                    int.TryParse(Console.ReadLine(), out int id);

                    var game = db.Games.Where(i => i.Id == id).FirstOrDefault();

                    if (game == null)
                    {
                        Console.WriteLine("Incorrect select");
                    }
                    else
                    {

                        Console.Write("\n\n1 - Name\n2 - Relese time\n3 - Style Id\n4 - Firma\nSelect change index  : ");
                        int.TryParse(Console.ReadLine(), out int index);

                        switch (index)
                        {
                            case 1:
                                Console.Write("Enter Name : ");
                                string name = Console.ReadLine();

                                game.Name = Console.ReadLine();
                                break;
                            case 2:
                                Console.Write("Enter Relese : ");
                                DateTime.TryParse(Console.ReadLine(), out DateTime dateTime);

                                game.ReleaseDate = dateTime;
                                break;
                            case 3:

                                Console.Write("Enter Style Name : ");
                                string styleName = Console.ReadLine();
                                var style = db.Styles.Where(i => i.Name.Equals(styleName)).First();

                                if (style!=null)
                                {
                                    game.Style = style;
                                }
                                else Console.WriteLine("Not found style");
                                break;
                            case 4:
                                Console.Write("Enter Firma Name : ");
                                string firmaName = Console.ReadLine();
                                var firma = db.Firms.Where(i => i.Name.Equals(firmaName)).First();

                                if (firma != null)
                                {
                                    game.Firma = firma;
                                }
                                else Console.WriteLine("Not found firma");
                                break;
                            default:
                                break;

                        }

                        db.SaveChanges();
                    }
                }
                else if (action == 14)
                {
                    try
                    {
                        Console.Write("Enter game  Name for delete : ");
                        string name = Console.ReadLine();

                        var item = db.Games.Where(x => x.Name.Equals(name)).FirstOrDefault();
                        if (item != null)
                        {
                            Console.WriteLine("Delete game?\n1 - Yes\n2 - o");
                            int.TryParse(Console.ReadLine(), out int index);
                            if (index == 1)
                            {
                                var gamesCount = db.Games.Count();
                                db.Remove(item);

                                if (gamesCount > db.Games.Count())
                                {
                                    db.SaveChanges();
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
                else if (action == 15)
                {
                    return;
                }

                Console.ReadKey();
                Console.Clear();
            } while (true);
        } 
    }
}
