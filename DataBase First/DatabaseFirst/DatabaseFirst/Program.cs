using DatabaseFirst.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DatabaseFirst
{
    class Program
    {
        static public void Print(ApplicationContext db)
        {
            var dbResult = db.Games.Include(f => f.Firma);
            var result = dbResult.Include(s => s.Style).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item.Id.ToString().PadRight(3, ' ') + item.Name.PadRight(18, ' ') + item.ReleaseDate.ToShortDateString().PadRight(15, ' ') + item.Firma.Name.PadRight(17, ' ') + item.Style.Name.PadRight(12, ' '));
            }
        }
        static void Main(string[] args)
        {
            ApplicationContext db = new ApplicationContext();

            Print(db);

            Game game = new Game() { Name = "Tom and Jerry", StyleId = 1, FirmaId = 1 };

            try
            {
                //Если добовлять одно и тоже то можеть дать Exeption()
                db.Games.Add(game);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();


            Print(db);
        }
    }
}
