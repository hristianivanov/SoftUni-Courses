--2
INSERT INTO Publishers ([Name],AddressId,Website,Phone)
VALUES ('Agman Games',	5,	'www.agmangames.com',	'+16546135542'),
	   ('Amethyst Games',	7,	'www.amethystgames.com','+15558889992'),
	   ('BattleBooks',	13,	'www.battlebooks.com',	'+12345678907')

INSERT INTO Boardgames ([Name],YearPublished,Rating,CategoryId,PublisherId,PlayersRangeId)
VALUES
		('Deep Blue',2019,5.67,1,15,7),
		('Paris',2016,9.78,7,1,5),
		('Catan: Starfarers',2021,9.87,7,13,6),
		('Bleeding Kansas',2020,3.25,3,7,4),
		('One Small Step',2019,5.75,5,9,2)

--3
UPDATE PlayersRanges
SET PlayersMax += 1
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET [Name] += 'V2'
WHERE YearPublished >= 2020

--4
DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN (1,16,31,47)

DELETE FROM Boardgames
WHERE PublisherId IN (1,16)

DELETE FROM Publishers
WHERE AddressId = 5

DELETE FROM Addresses
WHERE Town LIKE 'L%'

--5
SELECT [Name],Rating
FROM Boardgames
ORDER BY YearPublished,
[Name] DESC

--6
SELECT b.Id,
b.[Name],
YearPublished,
c.[Name] AS [CategoryName]
FROM Boardgames AS b
JOIN Categories AS c
ON c.Id = b.CategoryId
WHERE c.[Name] IN ('Strategy Games','Wargames')
ORDER BY YearPublished DESC

--7
SELECT c.Id,
CONCAT_WS(' ',c.FirstName,c.LastName) AS [CreatorName],
c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb
ON c.Id = cb.CreatorId
LEFT JOIN Boardgames AS bg
ON bg.Id = cb.BoardgameId
WHERE BoardgameId IS NULL
ORDER BY CreatorName

--8
SELECT TOP 5 bg.[Name], bg.Rating, c.[Name] AS [CategoryName]
FROM Boardgames AS bg
JOIN Categories AS c
ON c.Id = bg.CategoryId
JOIN PlayersRanges AS pr
ON pr.Id = bg.PlayersRangeId
WHERE bg.Rating > 7.00 AND bg.[Name] LIKE '%a%' OR bg.Rating > 7.50 AND (pr.PlayersMin = 2 AND pr.PlayersMax = 5)
ORDER BY bg.[Name], bg.Rating DESC

--9
SELECT CONCAT_WS(' ',c.FirstName,c.LastName) AS [FullName], Email, MAX(Rating)
FROM Creators AS c
JOIN CreatorsBoardgames AS cb
ON c.Id = cb.CreatorId
JOIN Boardgames AS bg
ON bg.Id = cb.BoardgameId
WHERE Email LIKE '%.com'
GROUP BY CONCAT_WS(' ',c.FirstName,c.LastName), Email
ORDER BY FullName

--10
SELECT 
		c.LastName, 
		CAST(AVG(CEILING(Rating)) AS INT) 
		AS [AverageRating], 
		p.[Name] 
		AS [PublisherName]
FROM Creators AS c
JOIN CreatorsBoardgames AS cb
ON c.Id = cb.CreatorId
JOIN Boardgames AS bg
ON bg.Id = cb.BoardgameId
JOIN Publishers AS p
ON p.Id = bg.PublisherId
WHERE p.[Name] = 'Stonemaier Games'
GROUP BY c.LastName,p.[Name]
ORDER BY AVG(Rating) DESC

GO
--11

CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT 
AS
	BEGIN

	DECLARE @count INT;
	SET @count = 
				(
					SELECT COUNT(bg.Id)
					FROM Creators AS c
					JOIN CreatorsBoardgames AS cb
					ON c.Id = cb.CreatorId
					JOIN Boardgames AS bg
					ON bg.Id = cb.BoardgameId
					WHERE c.FirstName = @name
					GROUP BY FirstName
				)
	IF(@count IS NULL)
		BEGIN
			SET @count = 0
		END
	RETURN @count
	END

--12
CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(50))
AS
BEGIN
	SELECT 
			bg.[Name],
			YearPublished,
			Rating,
			c.[Name] AS [CategoryName],
			p.[Name] AS [PublisherName],
			CAST(pr.PlayersMin AS VARCHAR(4)) + ' people' AS [MinPlayers],
			CAST(pr.PlayersMax AS VARCHAR(4)) + ' people' AS [MaxPlayers]
	FROM Boardgames AS bg
	JOIN Categories AS c
	ON c.Id = bg.CategoryId
	JOIN PlayersRanges AS pr
	ON pr.Id = bg.PlayersRangeId
	JOIN Publishers AS p
	ON p.Id = bg.PublisherId
	WHERE C.[Name] = @category
	ORDER BY PublisherName, YearPublished DESC
END
