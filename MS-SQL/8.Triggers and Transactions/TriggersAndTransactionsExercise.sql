USE Bank
GO

--1
CREATE TABLE Logs
(
	LogId INT IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum DECIMAL(18, 4),
	NewSum DECIMAL(18, 4)
)
GO

CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON  Accounts FOR UPDATE
AS
INSERT INTO Logs VALUES
(
	(SELECT Id FROM inserted),
	(SELECT Balance FROM deleted),
	(SELECT Balance FROM inserted)
)

--2
CREATE TABLE NotificationEmails
(
	Id INT IDENTITY,
	Recipient INT,
	[Subject] VARCHAR(255),
	Body VARCHAR(255)
)
GO

CREATE TRIGGER tr_CreateNewEmailOnNewLogEntry
ON Logs FOR INSERT
AS
INSERT INTO NotificationEmails VALUES
(
	(SELECT AccountId FROM inserted),
	(SELECT 'Balance change for account: ' + CAST(AccountId AS VARCHAR(255)) FROM inserted),
	(SELECT 'On ' + FORMAT(GETDATE(), 'MMM dd yyyy h:mmtt') + ' your balance was changed from ' + 
			CAST(OldSum AS VARCHAR(255)) + ' to ' + 
			CAST(NewSum AS VARCHAR(255)) + '.' 
	   FROM inserted)
)
GO

--3
CREATE PROCEDURE usp_DepositMoney(@AccountId INT,@MoneyAmount MONEY)
AS
	IF (@MoneyAmount < 0) 
		THROW 50001, 'Invalid amount', 1
	UPDATE [Accounts]
	SET [Balance] += @moneyAmount
	WHERE [Id] = @accountId
GO

--4
CREATE PROCEDURE usp_WithdrawMoney(@accountId INT,@moneyAmount MONEY)
AS
	IF(@moneyAmount< 0)
		THROW 50001, 'Invalid amount', 1
	UPDATE Accounts
	SET Balance -= @moneyAmount
	WHERE Id = @accountId
GO

--5
CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount MONEY)
AS
	BEGIN TRANSACTION
	BEGIN TRY
		EXEC usp_DepositMoney @receiverId, @amount
		EXEC usp_WithdrawMoney @senderId, @amount
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
	COMMIT TRANSACTION
GO

USE Diablo
GO

--6
	SELECT * 
	  FROM UsersGames

DECLARE @userGameId INT = 
							(
								SELECT ug.Id
							      FROM [UsersGames] 
									AS ug 
								INNER JOIN Users 
									AS u 
									ON ug.UserId = u.Id
								INNER JOIN Games 
									AS g 
									ON ug.GameId = g.Id
							     WHERE u.Username = 'Stamat' AND 
									   g.[Name] = 'Safflower'
							)

DECLARE @itemsCost DECIMAL(18, 4)
DECLARE @minLevel INT = 11
DECLARE @maxLevel INT = 12
DECLARE @playerCash DECIMAL(18, 4) = 
									(
										SELECT Cash
									      FROM UsersGames
									     WHERE Id = @userGameId
									)

SET @itemsCost = 
				(
					SELECT SUM(Price)
				      FROM Items
				     WHERE MinLevel BETWEEN @minLevel AND @maxLevel
				)

	IF (@playerCash >= @itemsCost)
BEGIN
	BEGIN TRANSACTION
		UPDATE UsersGames
		SET Cash -= @itemsCost
		WHERE Id = @userGameId
      
    INSERT INTO UserGameItems (ItemId, UserGameId)
    (
		SELECT
				Id,
				@userGameId
		  FROM Items
		 WHERE MinLevel BETWEEN @minLevel AND @maxLevel
	)
	COMMIT     
END

SET @minLevel = 19
SET @maxLevel = 21

	SET @playerCash = 
					 (
					 	SELECT Cash
					       FROM UsersGames
					      WHERE Id = @userGameId
					 )

SET @itemsCost = 
				(
					SELECT SUM(Price)
				      FROM Items
				     WHERE MinLevel BETWEEN @minLevel AND @maxLevel
				)

	IF (@playerCash >= @itemsCost)
BEGIN
	BEGIN TRANSACTION
		UPDATE UsersGames
		SET Cash -= @itemsCost
		WHERE Id = @userGameId
      
    INSERT INTO UserGameItems(ItemId, UserGameId)
    (
		SELECT
				Id,
				@userGameId
		  FROM Items
		 WHERE MinLevel BETWEEN @minLevel AND @maxLevel
	)
	COMMIT     
END

	SELECT i.[Name] 
		AS [Item Name]
	  FROM UserGameItems 
		AS ugi
		JOIN Items 
		AS i 
		ON i.Id = ugi.ItemId
		JOIN UsersGames 
		AS ug 
		ON ug.Id = ugi.UserGameId
		JOIN Games 
		AS g 
		ON g.Id = ug.GameId
	 WHERE g.[Name] = 'Safflower'
  ORDER BY [Item Name]
GO

USE SoftUni
GO

--8
CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
	SELECT *
	  FROM EmployeesProjects 
	    AS em
	LEFT JOIN Employees 
		AS e
		ON e.EmployeeID = em.EmployeeID
	  
--9
CREATE TABLE Deleted_Employees
(
	[EmployeeId] INT PRIMARY KEY IDENTITY, 
	[FirstName] VARCHAR(50), 
	[LastName] VARCHAR(50), 
	[MiddleName] VARCHAR(50), 
	[JobTitle] VARCHAR(50), 
	[DepartmentId] INT, 
	[Salary] DECIMAL(18, 2)
)
GO

-- Paste in Judge from this point on

CREATE TRIGGER tr_AddEntityToDeletedEmployeesTable
ON [Employees] FOR DELETE
AS
INSERT INTO [Deleted_Employees]	
	SELECT		
		[FirstName],
		[LastName],
		[MiddleName],
		[JobTitle],
		[DepartmentID],
		[Salary]
	FROM deleted

