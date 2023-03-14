USE Gringotts
GO

--1
	SELECT COUNT(*)
		AS [Count]
	  FROM WizzardDeposits

--2
	SELECT MAX(MagicWandSize)
		AS [LongestMagicWand]
	  FROM WizzardDeposits

--3
	SELECT 
			DepositGroup
			,MAX(MagicWandSize)
		AS [LongestMagicWand]
	  FROM WizzardDeposits
  GROUP BY DepositGroup

--4
	SELECT TOP 2
		   DepositGroup
	  FROM WizzardDeposits
  GROUP BY DepositGroup
  ORDER BY AVG(MagicWandSize)

--5
	SELECT 
			DepositGroup,
			SUM(DepositAmount)
		AS [TotalSum]
	  FROM WizzardDeposits
  GROUP BY DepositGroup

--6
		SELECT 
			DepositGroup,
			SUM(DepositAmount)
		AS [TotalSum]
	  FROM WizzardDeposits
	 WHERE MagicWandCreator = 'Ollivander family'
  GROUP BY DepositGroup

--7
	SELECT 
			DepositGroup,
			SUM(DepositAmount)
		AS [TotalSum]
	  FROM WizzardDeposits
	 WHERE MagicWandCreator = 'Ollivander Family'
  GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
  ORDER BY TotalSum DESC

--8
	SELECT
			DepositGroup,
			MagicWandCreator,
			MIN(DepositCharge)
	  FROM WizzardDeposits
  GROUP BY DepositGroup,MagicWandCreator
  ORDER BY MagicWandCreator,
		   DepositGroup

--9
	SELECT 
			a.AgeGroup,
			COUNT(*)
		AS [WizardCount]
	  FROM 
			(
				SELECT
				  CASE
						WHEN [Age] <= 10 THEN '[0-10]'
						WHEN [Age] > 10 AND [Age] <= 20 THEN '[11-20]'
						WHEN [Age] > 20 AND [Age] <= 30 THEN '[21-30]'
						WHEN [Age] > 30 AND [Age] <= 40 THEN '[31-40]'
						WHEN [Age] > 40 AND [Age] <= 50 THEN '[41-50]'
						WHEN [Age] > 50 AND [Age] <= 60 THEN '[51-60]'
						ELSE '[61+]'
				END AS [AgeGroup]
				  FROM [WizzardDeposits]
			)
		AS a
  GROUP BY a.AgeGroup

--10
	SELECT	a.FirstLetter
	  FROM 
			(
				SELECT 
						LEFT(FirstName,1)
					AS [FirstLetter]
				  FROM WizzardDeposits
				 WHERE DepositGroup = 'Troll Chest'
			)
		AS a
  GROUP BY a.FirstLetter

--11
	SELECT 
			DepositGroup,
			IsDepositExpired,
			AVG(DepositInterest)
		AS [AverageInterest]
	  FROM WizzardDeposits
	 WHERE DepositStartDate > '1985-01-01'
  GROUP BY DepositGroup,IsDepositExpired
  ORDER BY DepositGroup DESC,
		   IsDepositExpired

--12
	SELECT SUM(w1.DepositAmount - w2.DepositAmount)
		AS [SumDifference]
	  FROM WizzardDeposits AS w1
		LEFT JOIN WizzardDeposits 
		AS w2
		ON w1.Id = w2.Id - 1

--------------------------------------------------------------
USE SoftUni
GO

--13
	SELECT 
			DepartmentID,
			SUM(Salary)
		AS [TotalSalary]
	  FROM Employees
  GROUP BY DepartmentID
		   
--14
	SELECT
			DepartmentID,
			MIN(Salary)
		AS [MinimumSalery]
	  FROM Employees
	 WHERE DepartmentID IN (2,5,7) AND
		   HireDate > '2000-01-1'
  GROUP BY DepartmentID

--15
	SELECT * 
	  INTO NewTable
	  FROM Employees

	DELETE 
	  FROM NewTable
	 WHERE ManagerID = 42

	UPDATE NewTable
	   SET Salary += 5000
	 WHERE DepartmentID = 1

	SELECT 
			DepartmentID,
			AVG(Salary)
		AS [AverageSalary]
	  FROM NewTable
	 WHERE Salary > 30000
  GROUP BY DepartmentID

--16
	SELECT 
			a.DepartmentID,
			a.MaxSalary
	  FROM
			(
					SELECT
							DepartmentID,
							MAX(Salary)
						AS [MaxSalary]
					  FROM Employees
				  GROUP BY DepartmentID
			)
		AS a
	 WHERE a.MaxSalary NOT BETWEEN 30000 AND 70000

--17
	SELECT COUNT(*)
		AS [Count]
	  FROM Employees
	 WHERE ManagerID IS NULL

--18 
	SELECT
			DepartmentID,
			MAX(Salary)
		AS  [ThirdHighestSalary]
	  FROM (
				SELECT 
						DepartmentID,
						Salary,
						DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC)
					AS [Rank]
				  FROM Employees
		   )
		AS a
	 WHERE a.[Rank] = 3
  GROUP BY DepartmentID

--19
	SELECT TOP 10
			e.FirstName,
			e.LastName,
			e.DepartmentID
	  FROM Employees AS e
	INNER JOIN 
			(
				SELECT
						DepartmentID,
						AVG(Salary) AS [AverageSalary]
				  FROM Employees
			  GROUP BY DepartmentID
			)
		AS [AverageTable]
		ON e.DepartmentID = [AverageTable].DepartmentID
	 WHERE e.Salary > AverageTable.AverageSalary




