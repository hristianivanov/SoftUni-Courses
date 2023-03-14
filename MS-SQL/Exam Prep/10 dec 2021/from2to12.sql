--2
INSERT INTO Passengers(FullName,Email)
	SELECT 
		CONCAT_WS(' ',FirstName,LastName) 
		AS [FullName], 
		CONCAT(FirstName,LastName,'@gmail.com') 
		AS [Email]
	FROM Pilots
	WHERE Id BETWEEN 5 AND 15

--3
UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C','B') AND 
		(FlightHours IS NULL OR FlightHours <= 100) AND
		[Year] >= 2013
--4
DELETE FROM Passengers
WHERE LEN(FullName) <= 10

--5
SELECT
		Manufacturer,
		Model,
		FlightHours,
		Condition
FROM Aircraft
ORDER BY FlightHours DESC

--6
SELECT
	FirstName,
	LastName,
	Manufacturer,
	Model,
	FlightHours
FROM Pilots AS p
JOIN PilotsAircraft AS pa
ON pa.PilotId = p.Id
JOIN Aircraft AS a
ON a.Id = pa.AircraftId
WHERE FlightHours IS NOT NULL AND FlightHours < 304
ORDER BY FlightHours DESC,
		 FirstName

--7
SELECT TOP 20
	fd.Id
	AS [DestinationId],
	fd.[Start],
	p.FullName,
	a.AirportName,
	fd.TicketPrice
FROM FlightDestinations AS fd
JOIN Passengers AS p
ON p.Id = fd.PassengerId
JOIN Airports AS a
ON a.Id = fd.AirportId
WHERE DATEPART(day,[Start]) % 2 = 0
ORDER BY fd.TicketPrice DESC,
		 a.AirportName

--8
SELECT 
	a.Id AS [AircraftId],
	a.Manufacturer,
	a.FlightHours,
	COUNT(a.Id) AS [FlightDestinationsCount],
	ROUND(AVG(TicketPrice),2) AS [AvgPrice]
FROM Aircraft AS a
JOIN FlightDestinations AS fd
ON fd.AircraftId = a.Id
GROUP BY a.Id,a.Manufacturer,a.FlightHours
HAVING COUNT(fd.Id) >= 2
ORDER BY FlightDestinationsCount DESC, AircraftId

--9
SELECT 
	p.FullName,
	t.CountOfAircraft,
	SUM(fd.TicketPrice) AS [TotalPayed]
FROM Passengers AS p
JOIN FlightDestinations AS fd
ON fd.PassengerId = p.Id
JOIN 
	(
		SELECT  
				PassengerId,
				COUNT(AircraftId) AS [CountOfAircraft]
		FROM FlightDestinations
		GROUP BY PassengerId
	) AS t 
ON p.Id = t.PassengerId 
WHERE p.FullName LIKE '_a%'
GROUP BY p.FullName, CountOfAircraft
HAVING CountOfAircraft > 1
ORDER BY p.FullName

--10
SELECT 
		ap.AirportName,
		fd.[Start] AS [DayTime],
		fd.TicketPrice,
		p.FullName,
		ac.Manufacturer,
		ac.Model
FROM Airports AS ap
JOIN FlightDestinations AS fd
ON fd.AirportId = ap.Id
JOIN Passengers AS p
ON p.Id = fd.PassengerId
JOIN Aircraft AS ac
ON ac.Id = fd.AircraftId
WHERE DATEPART(HOUR,fd.[Start]) BETWEEN 6 AND 20 AND fd.TicketPrice > 2500
ORDER BY ac.Model

GO
--11
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50)) 
RETURNS INT 
AS
	BEGIN
	DECLARE @passengerId INT;
	SET @passengerId = 
						(
							SELECT Id
							FROM Passengers
							WHERE Email = @email
						)
	DECLARE @count INT;
	SET @count = 
	(
					SELECT COUNT(PassengerId)
					FROM FlightDestinations
					WHERE PassengerId = @passengerId
	)
	RETURN @count
	END

GO

--12
CREATE PROCEDURE usp_SearchByAirportName @airportName VARCHAR(70)
AS
	BEGIN
			SELECT 
					a.AirportName,
					p.FullName,
					CASE 
							WHEN (fd.TicketPrice <= 400) THEN 'Low'
							WHEN (fd.TicketPrice BETWEEN 401 AND 1500) THEN 'Medium'
							ELSE 'High'
					END AS [LevelOfTickerPrice],
					ac.Manufacturer,
					ac.Condition,
					t.TypeName
			FROM Airports AS a
			JOIN FlightDestinations AS fd ON fd.AirportId = a.Id
			JOIN Passengers AS p ON p.Id = fd.PassengerId
			JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
			JOIN AircraftTypes AS t ON t.Id = ac.TypeId
			WHERE a.AirportName = @airportName
			ORDER BY ac.Manufacturer, p.FullName
	END
