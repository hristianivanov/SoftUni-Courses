USE SoftUni
GO

--1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
	SELECT
			FirstName,
			LastName
	  FROM Employees
	 WHERE Salary > 35000
GO

--2
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@number DECIMAL(18,4))
AS
	SELECT
			FirstName,
			LastName
	  FROM Employees
	 WHERE Salary >= @number
GO

--3
CREATE PROC usp_GetTownsStartingWith(@substring VARCHAR(50))
AS
	SELECT
		[Name] AS [Town]
	FROM [Towns]
	WHERE LEFT([Name],LEN(@substring)) = @substring
GO

--4
CREATE PROCEDURE usp_GetEmployeesFromTown(@townName VARCHAR(50))
AS
	SELECT	
			e.FirstName
		AS [First Name],
			e.LastName
		AS [Last Name]
	  FROM Addresses
		AS a
	  JOIN Towns
		AS t
		ON a.TownID = t.TownID
	  JOIN Employees
		AS e
		ON e.AddressID = a.AddressID
	 WHERE t.[Name] = @townName
GO

--5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
	BEGIN
	DECLARE @salaryLevel VARCHAR(10)
			IF(@salary < 30000) 
				SET @salaryLevel = 'Low'
			ELSE IF(@salary BETWEEN 30000 AND 50000) 
				SET @salaryLevel = 'Average'
			ELSE 
				SET @salaryLevel = 'High'

		RETURN @salaryLevel
	  END
GO

--6
CREATE PROCEDURE usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS
	SELECT
			FirstName
		AS [First Name],
			LastName
		AS [Last Name]
	  FROM Employees
	 WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
GO

--7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
AS
	BEGIN
			DECLARE @wordIndex INT = 1
			WHILE(@wordIndex <= LEN(@word))
			BEGIN
					DECLARE @currCharacter CHAR = SUBSTRING(@word,@wordIndex,1)
					IF (CHARINDEX(@currCharacter,@setOfLetters) = 0)
						RETURN 0
					ELSE 
						SET @wordIndex += 1
			  END
			RETURN 1
	  END
GO

--8
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL
	
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN
						(
							SELECT EmployeeID 
							  FROM Employees
							 WHERE DepartmentID = @departmentId
						)

	UPDATE Employees
	   SET ManagerID = NULL
	 WHERE ManagerID IN
						(
							SELECT EmployeeID 
							  FROM Employees
						     WHERE DepartmentID = @departmentId
						)
	
	UPDATE Departments
	   SET ManagerID = NULL
	 WHERE DepartmentID = @departmentId
	
 	DELETE FROM Employees
	 WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	 WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	 WHERE DepartmentID = @departmentId
GO
--------------------------------------------------
USE Bank
GO
--9

CREATE PROC usp_GetHoldersFullName
AS
	SELECT
		CONCAT(FirstName,' ',LastName)
	FROM AccountHolders
GO

--10
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(18,4))
AS
	SELECT
			a.FirstName,
			a.LastName		
	  FROM AccountHolders 
		AS a
		JOIN
			(
				SELECT 
					AccountHolderId,
					SUM(Balance) 
					AS TotalMoney
				  FROM Accounts
				GROUP BY AccountHolderId
			) 
		AS acc 
		ON a.Id = acc.AccountHolderId
	 WHERE acc.TotalMoney > @number
  ORDER BY a.FirstName, a.LastName
GO

--11
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18, 4), @annualRate FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
AS
	BEGIN
		RETURN @sum * POWER(1 + @annualRate, @years)
	END
GO

--12
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accountId INT, @annualRate FLOAT)
AS
	SELECT
			acc.Id 
		AS [Account Id],
			h.FirstName
		AS [First Name],
			h.LastName 
		AS [Last Name],
			acc.Balance 
		AS [Current Balance],
			dbo.ufn_CalculateFutureValue(acc.Balance, @annualRate, 5) 
		AS [Balance in 5 years]
	  FROM Accounts 
		AS acc
		JOIN AccountHolders 
		AS h
		ON acc.AccountHolderId = h.Id
	 WHERE acc.Id = @accountId
GO

USE Diablo
GO

--13
CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
  RETURNS TABLE
             AS
         RETURN
                (
                    SELECT SUM(Cash)
                        AS [SumCash]
                      FROM (
                                SELECT g.[Name],
                                       ug.Cash,
                                       ROW_NUMBER() OVER(ORDER BY ug.Cash DESC)
                                    AS [RowNumber]
                                  FROM UsersGames
                                    AS ug
								  JOIN Games
                                    AS g
                                    ON ug.GameId = g.Id
                                 WHERE g.[Name] = @gameName
                           ) 
                        AS [RankingSubQuery]
                     WHERE RowNumber % 2 <> 0
                 )