using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstGamesSecond.Migrations
{
    public partial class CreateProcedurs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var DeleteByZeroGame = @"CREATE PROCEDURE DeleteByZeroGame
                       AS
                       BEGIN 
                            
                           DELETE FROM Games
                           WHERE Games.Id = ANY (SELECT Sales.GameId FROM Sales 
                                                 GROUP BY Sales.GameId 
                                                 HAVING SUM(Sales.Quantity) = 0 )  
                       END";

            migrationBuilder.Sql(DeleteByZeroGame);

               var DeleteByCount = @"CREATE PROCEDURE DeleteByCount
                                     @count INT
                                     AS
                                     BEGIN 
                                          
                                         DELETE FROM Games
                                         WHERE Games.Id = ANY (SELECT Sales.GameId FROM Sales 
                                                               GROUP BY Sales.GameId 
                                                               HAVING SUM(Sales.Quantity) = @count )  
                                     END";

            migrationBuilder.Sql(DeleteByCount);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
