USE SoftUni
GO

--1
	SELECT TOP 5
		   EmployeeID,
		   JobTitle,
		   e.AddressID,
		   a.AddressText
	  FROM Employees
		AS e
 LEFT JOIN Addresses
		AS a
		ON a.AddressID = e.AddressID
	ORDER BY AddressID

--2
	SELECT TOP 50
		   e.FirstName,
		   e.LastName,
		   t.Name
		AS [Town],
		   a.AddressText
	  FROM Employees
		AS e
 LEFT JOIN Addresses
		AS a
		ON a.AddressID = e.AddressID
INNER JOIN Towns
		AS t
		ON t.TownID = a.TownID
  ORDER BY FirstName,
		   LastName

--3
	SELECT e.EmployeeID,
		   e.FirstName,
		   e.LastName,
		   d.[Name]
		AS [DepartmentName]
	  FROM Employees
		AS e
	LEFT JOIN Departments
		AS d
		ON d.DepartmentID = e.DepartmentID
  WHERE d.[Name] = 'Sales'
  ORDER BY EmployeeID

--4
	SELECT TOP 5
		   e.EmployeeID,
		   e.FirstName,
		   e.Salary,
		   d.[Name]
		AS [DepartmentName]
	  FROM Employees
		AS e
	  JOIN Departments
		AS d
		ON d.DepartmentID = e.DepartmentID
	 WHERE Salary >= 15000
 ORDER BY e.DepartmentID

--5
	SELECT TOP 3
			e.EmployeeID,
			e.FirstName
	  FROM Employees 
		AS e
 LEFT JOIN EmployeesProjects 
		AS ep
		ON ep.EmployeeID = e.EmployeeID
	 WHERE ep.ProjectID IS NULL
  ORDER BY e.EmployeeID

--6
	SELECT 
			e.FirstName,
			e.LastName,
			e.HireDate,
			d.[Name]
		AS [DeptName]
	  FROM Employees
		AS e
	  JOIN Departments
		AS d
		ON d.DepartmentID = e.DepartmentID
	 WHERE e.HireDate > '1999-01-1' AND
		   d.[Name] IN (
							'Sales'
							,'Finance'
					   )
  ORDER BY e.HireDate

--7
	SELECT TOP 5
			e.EmployeeID,
			e.FirstName,
			p.[Name]
		AS [ProjectName]
	  FROM EmployeesProjects
		AS ep
	INNER JOIN Employees
		AS e
		ON e.EmployeeID = ep.EmployeeID
	INNER JOIN Projects
		AS p
		ON p.ProjectID = ep.ProjectID
	 WHERE p.StartDate > '2002-08-13' AND
	 p.EndDate IS NULL
  ORDER BY EmployeeID

--8
	SELECT	
			e.EmployeeID,
			e.FirstName,
				CASE 
					WHEN YEAR(p.StartDate) >= 2005 THEN NULL
					ELSE p.[Name]
				END
		AS [ProjectName]
	  FROM EmployeesProjects
		AS ep
	INNER JOIN Employees
		AS e
		ON e.EmployeeID = ep.EmployeeID
	INNER JOIN Projects
		AS p
		ON p.ProjectID = ep.ProjectID
	 WHERE e.EmployeeID = 24

--9
	SELECT 
			e.EmployeeID,
			e.FirstName,
			e.ManagerID,
			m.FirstName
	  FROM Employees
		AS e
	INNER JOIN Employees
		AS m
		ON e.ManagerID = m.EmployeeID
	 WHERE e.ManagerID IN (3,7)
  ORDER BY EmployeeID

--10
	SELECT TOP 50
			e.EmployeeID,
			CONCAT_WS(' ',e.FirstName,e.LastName)
		AS [EmployeeName],
			CONCAT_WS(' ',m.FirstName,m.LastName)
		AS [ManagerName],
			d.[Name]
		AS [DepartmentName]
	  FROM Employees
		AS e
	INNER JOIN Departments
		AS d
		ON d.DepartmentID = e.DepartmentID
	INNER JOIN Employees
		AS m
		ON e.ManagerID = m.EmployeeID
  ORDER BY e.EmployeeID

--11
	SELECT
			MIN(a.AverageSalary)
		AS [MinAverageSalary]
	  FROM (
				SELECT AVG(Salary) 
					AS [AverageSalary] 
				  FROM Employees
			  GROUP BY DepartmentID
		   )
		AS a

USE [Geography]
GO

--12
	SELECT 
			c.CountryCode,
			m.MountainRange,
			p.PeakName,
			p.Elevation
	  FROM MountainsCountries
		AS mc
	INNER JOIN Countries
		AS c
		ON c.CountryCode = mc.CountryCode
	INNER JOIN Mountains
		AS m 
		ON m.Id = mc.MountainId
	INNER JOIN Peaks
		AS p
		ON p.MountainId = m.Id
	 WHERE c.CountryName = 'Bulgaria' AND
		   p.Elevation > 2835
  ORDER BY p.Elevation DESC

--13
	SELECT 
			CountryCode,
			COUNT(MountainId)
		AS [MountainRangess]
	  FROM MountainsCountries
	 WHERE CountryCode IN
			(
				SELECT CountryCode
				  FROM Countries
				 WHERE CountryName in 
				 (
					'United States', 'Russia', 'Bulgaria'
				 )
			)
  GROUP BY CountryCode

--14
	SELECT TOP 5 
			c.CountryName,
			r.RiverName
	  FROM Countries
		AS c
	LEFT JOIN CountriesRivers
		AS cr
		ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers
		AS r
		ON r.Id = cr.RiverId
	 WHERE c.ContinentCode = (
								SELECT ContinentCode
								  FROM Continents
								 WHERE ContinentName = 'Africa'
							 )
  ORDER BY c.CountryName

--15
	SELECT 
			ContinentCode,
			CurrencyCode,
			CurrencyUsage
     FROM (
            SELECT *,
                   DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC)
                AS [CurrencyRank]
              FROM (
						SELECT 
							   ContinentCode,
							   CurrencyCode,
							   COUNT(*)
                            AS [CurrencyUsage]
                          FROM Countries
                      GROUP BY ContinentCode, CurrencyCode
                        HAVING COUNT(*) > 1
                   )
                AS [CurrencyUsageSubquery]
          )
    AS CurrencyRankingSubquery
 WHERE CurrencyRank = 1

--16
	SELECT
		   COUNT(c.CountryCode) 
		AS [Count]
	  FROM Countries 
		AS c
	LEFT JOIN MountainsCountries 
		AS mc
		ON c.CountryCode = mc.CountryCode
	 WHERE mc.MountainId IS NULL

--17
	SELECT TOP 5
		   c.CountryName,
		   MAX(p.Elevation)
		AS [HighestPeakElevation],
		   MAX(r.[Length])
		AS [LongestRiverLength]
	  FROM Countries
		AS c
	LEFT JOIN MountainsCountries
		AS mc
		ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains 
		AS m
		ON m.Id = mc.MountainId
	LEFT JOIN Peaks
		AS p
		ON p.MountainId = m.Id
	LEFT JOIN CountriesRivers
		AS cr
		ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers
		AS r
		ON r.Id = cr.RiverId
  GROUP BY c.CountryName
  ORDER BY HighestPeakElevation DESC,
		   LongestRiverLength DESC,
		   c.CountryName ASC

--18
	SELECT TOP 5 
			CountryName
		AS Country,
         ISNULL(PeakName, '(no highest peak)')
		AS [Highest Peak Name],
         ISNULL(Elevation, 0)
		AS [Highest Peak Elevation],
         ISNULL(MountainRange, '(no mountain)')
		AS [Mountain]
	  FROM (
               SELECT c.CountryName,
                      p.PeakName,
                      p.Elevation,
                      m.MountainRange,
                      DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC)
                   AS PeakRank
                 FROM Countries
                   AS c
            LEFT JOIN MountainsCountries
                   AS mc
                   ON mc.CountryCode = c.CountryCode
            LEFT JOIN Mountains
                   AS m
                   ON mc.MountainId = m.Id
            LEFT JOIN Peaks
                   AS p
                   ON p.MountainId = m.Id
         ) 
		AS [PeakRankingSubquery]
     WHERE PeakRank = 1
  ORDER BY Country,
		   [Highest Peak Name]

