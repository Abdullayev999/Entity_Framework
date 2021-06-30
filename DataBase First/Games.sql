CREATE DATABASE Gaming

GO
USE Gaming
 
CREATE TABLE Styles
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL ,  

	CONSTRAINT CK_Styles_Name CHECK([Name]!=' '),
	CONSTRAINT UQ_Styles_Name UNIQUE([Name])
)

CREATE TABLE  Firms
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL ,  

	CONSTRAINT CK_Firms_Name CHECK([Name]!=' '),
	CONSTRAINT UQ_Firms_Name UNIQUE([Name])
) 

CREATE TABLE Games
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL , 
	ReleaseDate DATE NOT NULL DEFAULT(GETDATE()),
	StyleId INT NOT NULL,
	FirmaId INT NOT NULL,

	CONSTRAINT CK_Games_Name CHECK([Name]!=' '),
	CONSTRAINT UQ_Games_Name UNIQUE([Name]),
	CONSTRAINT CK_Games_ReleaseDate CHECK(ReleaseDate <= GETDATE()) ,
	CONSTRAINT FK_Games_StyleId FOREIGN KEY (StyleId) REFERENCES Styles(Id),
	CONSTRAINT FK_Games_FirmaId FOREIGN KEY (FirmaId) REFERENCES Firms(Id)
)


INSERT INTO Firms ([Name]) VALUES ('Konami')
INSERT INTO Firms ([Name]) VALUES ('Electronic Arts')
INSERT INTO Firms ([Name]) VALUES ('Bandai Namco')


INSERT INTO Styles ([Name]) VALUES ('Simulation')
INSERT INTO Styles ([Name]) VALUES ('Strategy')
INSERT INTO Styles ([Name]) VALUES ('Sport')


INSERT INTO Games ([Name],ReleaseDate,StyleId,FirmaId)  VALUES ('World of Tank','2012-10-10',2,2)
INSERT INTO Games ([Name],ReleaseDate,StyleId,FirmaId)  VALUES ('Tarzan','2008-01-01',1,3)
INSERT INTO Games ([Name],ReleaseDate,StyleId,FirmaId)  VALUES ('Pes2015','2015-08-11',3,1)
INSERT INTO Games ([Name],ReleaseDate,StyleId,FirmaId)  VALUES ('Spider Man','2004-07-02',1,2)
INSERT INTO Games ([Name],ReleaseDate,StyleId,FirmaId)  VALUES ('Mario','2000-02-08',1,3)
INSERT INTO Games ([Name],ReleaseDate,StyleId,FirmaId)  VALUES ('Need for Speed','2007-09-10',3,2)
INSERT INTO Games ([Name],ReleaseDate,StyleId,FirmaId)  VALUES ('Hulk','2005-06-01',1,1)



