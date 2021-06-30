--1  - Показать топ-3 студий с максимальным количеством игр 
CREATE FUNCTION TopFirmsByMaxCountGame(@top INT = 3 )
RETURNS TABLE 
RETURN  SELECT TOP (@top) Firms.[Name], COUNT(*) AS 'Count' FROM Games
JOIN Firms ON Games.FirmaId = Firms.Id
GROUP BY Firms.[Name] 
ORDER BY COUNT(*) DESC



--2  - Показать студию с максимальным количеством игр 
CREATE FUNCTION MaxFimaByCounGame()
RETURNS TABLE  
RETURN (SELECT TOP 1 Firms.[Name],COUNT(*) AS 'Count' FROM Games
JOIN Firms ON Games.FirmaId = Firms.Id
GROUP BY Firms.[Name] 
ORDER BY COUNT(*) DESC)  



--3  - Показать топ-3 самых популярных стилей по количеству игр
CREATE FUNCTION TopStyleByMaxCountGame(@top INT = 3)
RETURNS TABLE 
RETURN  SELECT TOP (@top) Styles.[Name] , COUNT(*) AS 'Count' FROM Games
JOIN Styles ON Games.StyleId = Styles.Id
GROUP BY Styles.[Name] 
ORDER BY COUNT(*) DESC



--4  - Показать самый популярный стиль по количеству игр
CREATE FUNCTION PopulationStyleByCountGame()
RETURNS TABLE  
RETURN (SELECT TOP 1 Styles.[Name],COUNT(*) AS 'Count' FROM Games
JOIN Styles ON Games.StyleId = Styles.Id
GROUP BY Styles.[Name] 
ORDER BY COUNT(*) DESC) 



--5  - Показать топ-3 самых популярных стилей по количеству продаж 
CREATE FUNCTION TopStyleBySalesCountGame(@top INT = 3)
RETURNS TABLE  
RETURN (SELECT TOP (@top) Styles.[Name],SUM(Sales.Quantity) AS 'Count' FROM Sales
JOIN Games ON Games.Id = Sales.GameId
JOIN Styles ON Games.StyleId = Styles.Id
GROUP BY Styles.[Name] 
ORDER BY SUM(Sales.Quantity) DESC) 
 


--6  - Показать самый популярный стиль по количеству продаж
CREATE FUNCTION PopulationStyleBySalesGame()
RETURNS TABLE  
RETURN (SELECT TOP 1 Styles.[Name],SUM(Sales.Quantity) AS 'Count' FROM Sales
JOIN Games ON Games.Id = Sales.GameId
JOIN Styles ON Games.StyleId = Styles.Id
GROUP BY Styles.[Name] 
ORDER BY SUM(Sales.Quantity) DESC) 



--7  - Показать топ-3 самых популярных однопользовательских игр по количеству продаж
CREATE FUNCTION TopGameByNotMultiplayerByCountSales(@top INT = 3)
RETURNS TABLE  
RETURN (SELECT TOP (@top) Games.[Name],SUM(Sales.Quantity) AS 'Count' FROM Sales
JOIN Games ON Games.Id = Sales.GameId 
WHERE Games.IsMultiplayer ='no'
GROUP BY Games.[Name] 
ORDER BY SUM(Sales.Quantity) DESC) 
 


--8  - Показать топ-3 самых популярных многопользовательских игр по количеству продаж
CREATE FUNCTION TopGameByMultiplayerByCountSales(@top INT = 3)
RETURNS TABLE  
RETURN (SELECT TOP (@top) Games.[Name],SUM(Sales.Quantity) AS 'Count' FROM Sales
JOIN Games ON Games.Id = Sales.GameId 
WHERE Games.IsMultiplayer ='yes'
GROUP BY Games.[Name] 
ORDER BY SUM(Sales.Quantity) DESC) 



--9 -  Показать самую популярную однопользовательскую игру по количеству продаж
CREATE FUNCTION PopulationGameByNotMultiplayerByCountSales()
RETURNS TABLE  
RETURN (SELECT TOP 1 Games.[Name],SUM(Sales.Quantity) AS 'Count' FROM Sales
JOIN Games ON Games.Id = Sales.GameId 
WHERE Games.IsMultiplayer ='no'
GROUP BY Games.[Name] 
ORDER BY SUM(Sales.Quantity) DESC) 



--10 - Показать самую популярную многопользовательскую игру по количеству продаж
CREATE FUNCTION PopulationGameByMultiplayerByCountSales()
RETURNS TABLE  
RETURN (SELECT TOP 1 Games.[Name],SUM(Sales.Quantity) AS 'Count' FROM Sales
JOIN Games ON Games.Id = Sales.GameId 
WHERE Games.IsMultiplayer ='yes'
GROUP BY Games.[Name] 
ORDER BY SUM(Sales.Quantity) DESC) 



--11 - Показать самую популярную игру по количеству продаж
CREATE FUNCTION PopulationGamByCountSales()
RETURNS TABLE  
RETURN (SELECT TOP 1 Games.[Name],SUM(Sales.Quantity) AS 'Count' FROM Sales
JOIN Games ON Games.Id = Sales.GameId  
GROUP BY Games.[Name] 
ORDER BY SUM(Sales.Quantity) DESC) 







--Задание 2. Добавьте новую функциональность к проекту об играх: 
--- Напишите процедуру, которая удаляет все игры с количеством продаж равным нулю; 
--- Напишите процедуру, которая удаляет все игры с количеством продаж равным параметру, переданному в процедуру

CREATE PROCEDURE DeleteByZeroGame
AS
BEGIN 
     
    DELETE FROM Games
    WHERE Games.Id = ANY (SELECT Sales.GameId FROM Sales 
                          GROUP BY Sales.GameId 
                          HAVING SUM(Sales.Quantity) = 0 )  
END



CREATE PROCEDURE DeleteByCount
@count INT
AS
BEGIN 
     
    DELETE FROM Games
    WHERE Games.Id = ANY (SELECT Sales.GameId FROM Sales 
                          GROUP BY Sales.GameId 
                          HAVING SUM(Sales.Quantity) = @count )  
END

