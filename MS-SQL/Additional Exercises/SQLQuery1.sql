USE Diablo
GO

--1. Number of Users for Email Provider
SELECT 
		a.[Email Provider],
		COUNT(*) AS [Numbers of Users]
FROM 
	(
		SELECT SUBSTRING(Email,CHARINDEX('@',Email) + 1,LEN(Email)) AS [Email Provider]
		FROM Users 
	) AS a
GROUP BY a.[Email Provider]
ORDER BY [Numbers of Users] DESC,a.[Email Provider]

--2. All User in Games
SELECT 
		g.[Name] AS [Game],
		gt.[Name] AS [Game Type],
		u.Username,
		ug.[Level],
		ug.Cash,
		c.[Name] AS [Character]
FROM Games AS g
JOIN GameTypes AS gt
ON g.GameTypeId = gt.Id
JOIN UsersGames AS ug
ON ug.GameId = g.Id
JOIN Users AS u
ON u.Id = ug.UserId
JOIN Characters AS c
ON c.Id = ug.CharacterId
ORDER BY ug.[Level] DESC, u.Username, Game

--3. Users in Games with Their Items
SELECT
	u.Username,
	g.[Name] AS Game,
	COUNT(ugi.ItemId) AS [Items Count],
	SUM(i.Price) AS [Items Price]
FROM Users AS u
JOIN UsersGames AS ug 
ON u.Id = ug.UserId
JOIN Games AS g 
ON g.Id = ug.GameId
JOIN UserGameItems AS ugi 
ON ug.Id = ugi.UserGameId
JOIN Items AS i 
ON ugi.ItemId = i.Id
GROUP BY u.Username, g.[Name]
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, Username

--4. *User in Games with Their Statistics
SELECT 
	u.Username, 
	g.Name as Game, 
	MAX(c.Name) as [Character],
	SUM(sts.Strength) + MAX(st.Strength) + MAX(cs.Strength) as Strength,
	SUM(sts.Defence) + MAX(st.Defence) + MAX(cs.Defence) as Defence,
	SUM(sts.Speed) + MAX(st.Speed) + MAX(cs.Speed) as Speed,
	SUM(sts.Mind) + MAX(st.Mind) + MAX(cs.Mind) as Mind,
	SUM(sts.Luck) + MAX(st.Luck) + MAX(cs.Luck) as luck
FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId = u.id
JOIN Games AS g ON ug.GameId = g.Id
JOIN GameTypes gt ON gt.Id = g.GameTypeId
JOIN [Statistics] AS st ON st.Id = gt.BonusStatsId
JOIN Characters AS c ON ug.CharacterId = c.Id
JOIN [Statistics] cs ON cs.Id = c.StatisticId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN items AS i ON i.Id = ugi.ItemId
JOIN [Statistics] AS sts ON sts.Id = i.StatisticId
GROUP BY u.Username, g.Name
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC

--5. All Items with Greater than Average Statistics
DECLARE @averageMind DECIMAL(8, 2) = (SELECT AVG(Mind) FROM [Statistics])
DECLARE @averageLuck DECIMAL(8, 2) = (SELECT AVG(Luck) FROM [Statistics])
DECLARE @averageSpeed DECIMAL(8, 2) = (SELECT AVG(Speed) FROM [Statistics])

SELECT
		i.[Name],
		i.Price,
		i.MinLevel,
		s.Strength,
		s.Defence,
		s.Speed,
		s.Luck,
		s.Mind
FROM Items AS i
JOIN [Statistics] AS s
ON s.Id = i.StatisticId
WHERE s.Mind > @averageMind AND s.Luck > @averageLuck AND s.Speed > @averageSpeed
ORDER BY i.[Name]








