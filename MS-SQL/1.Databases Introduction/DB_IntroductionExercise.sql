--4
INSERT INTO Towns VALUES
	(1, 'Sofia')
	,(2, 'Plovdiv')
	,(3, 'Varna')

INSERT INTO Minions VALUES
	(1, 'Kevin', 22, 1)
	,(2, 'Bob', 15, 3)
	,(3, 'Steward', NULL, 2)

--7
CREATE TABLE People
(
	Id INT IDENTITY PRIMARY KEY
	,[Name] NVARCHAR(200) NOT NULL
	,Picture IMAGE
	,Height REAL
	,[Weight] REAL
	,Gender CHAR(1) NOT NULL
	,Birthdate DATE NOT NULL
	,Biography NVARCHAR(MAX)
)

--8
CREATE TABLE Users
(
	Id INT IDENTITY PRIMARY KEY
	,Username VARCHAR(30) UNIQUE NOT NULL
	,[Password] VARCHAR(26) NOT NULL
	,ProfilePricture IMAGE
	,LastLoginTime DATETIME
	,IsDeleted BIT
)


INSERT INTO [Users] VALUES
	('Username 1', 'Password 1', NULL, NULL, 0),
	('Username 2', 'Password 2', NULL, NULL, 0),
	('Username 3', 'Password 3', NULL, NULL, 0),
	('Username 4', 'Password 4', NULL, NULL, 1),
	('Username 5', 'Password 5', NULL, NULL, 1)

INSERT INTO People VALUES
	('John', NULL, 1.80, 72.00, 'm', '2001-12-01', 'John bio')
	,('Jane', NULL, 1.71, 58.00, 'f', '2002-11-15', 'Jane bio')
	,('Jim', NULL, 1.68, 95.00, 'm', '1998-02-02', 'Jim bio')
	,('Jenna', NULL, 1.64, 49.00, 'f', '2004-06-09', 'Jenna bio')
	,('Jack', NULL, 1.83, 80.00, 'm', '1985-09-24', 'Jack bio')

--13
CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY
	,DirectorName VARCHAR(50) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY
	,GenreName VARCHAR(50) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY
	,CategoryName VARCHAR(50) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY
	,Title VARCHAR(50) NOT NULL
	,DirectorId INT FOREIGN KEY REFERENCES [Directors](Id) NOT NULL
	,CopyrightYear INT NOT NULL
	,Length TIME NOT NULL
	,GenreId INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
	,Rating DECIMAL(2, 1) NOT NULL
	,Notes NVARCHAR(1000)
)

INSERT INTO Directors VALUES
	('Stanley Kubrick', NULL)
	,('Alfred Hitchcock', NULL)
	,('Quentin Tarantino', NULL)
	,('Steven Spielberg', NULL)
	,('Martin Scorsese', NULL)

INSERT INTO Genres VALUES
	('Action', NULL)
	,('Comedy', NULL)
	,('Drama', NULL)
	,('Fantasy', NULL)
	,('Horror', NULL)

INSERT INTO Categories VALUES
	('Short', NULL)
	,('Long', NULL)
	,('Biography', NULL)
	,('Documentary', NULL)
	,('TV', NULL)

INSERT INTO Movies VALUES
	('The Shawshank Redemption', 1, 1994, '02:22:00', 2, 3, 9.4, NULL)
	,('The Godfather', 2, 1972, '02:55:00', 3, 4, 9.2, NULL)
	,('Schindler`s List', 3, 1993, '03:15:00', 4, 5, 9.0, NULL)
	,('Pulp Fiction', 4, 1994, '02:34:00', 5, 1, 8.9, NULL)
	,('Fight Club', 5, 1999, '02:19:00', 1, 2, 8.8, NULL)

--14
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY
	,CategoryName VARCHAR(50) NOT NULL
	,DailyRate DECIMAL(6, 2) NOT NULL
	,WeeklyRate DECIMAL(6, 2) NOT NULL
	,MonthlyRate DECIMAL(6, 2) NOT NULL
	,WeekendRate DECIMAL(6, 2) NOT NULL
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY
	,PlateNumber VARCHAR(30) NOT NULL
	,Manufacturer VARCHAR(50) NOT NULL
	,Model VARCHAR(50) NOT NULL
	,CarYear INT NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,Doors INT NOT NULL
	,Picture IMAGE
	,Condition NVARCHAR(1000) NOT NULL
	,Available BIT NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY
	,FirstName VARCHAR(30) NOT NULL
	,LastName VARCHAR(30) NOT NULL
	,Title VARCHAR(50) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY
	,DriverLicenceNumber INT NOT NULL
	,FullName VARCHAR(50) NOT NULL
	,Address VARCHAR(200) NOT NULL
	,City VARCHAR(50) NOT NULL
	,ZIPCode INT NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY
	,EmployeeId INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL
	,CustomerId INT FOREIGN KEY REFERENCES [Customers](Id) NOT NULL
	,CarId INT FOREIGN KEY REFERENCES [Cars](Id) NOT NULL
	,TankLevel INT NOT NULL
	,KilometrageStart INT NOT NULL
	,KilometrageEnd INT NOT NULL
	,TotalKilometrage INT NOT NULL
	,StartDate DATE NOT NULL
	,EndDate DATE NOT NULL
	,TotalDays INT NOT NULL
	,RateApplied DECIMAL(6, 2) NOT NULL
	,TaxRate DECIMAL(4, 2) NOT NULL
	,OrderStatus VARCHAR(50) NOT NULL
	,Notes NVARCHAR(1000)
)

INSERT INTO Categories VALUES
	('First category name', 10.00, 50.00, 150.00, 20.00)
	,('Second category name', 50.00, 250.00, 750.00, 100.00)
	,('Third category name', 100.00, 500.00, 1500.00, 200.00)

INSERT INTO Cars VALUES
	('PLN 0001', 'Ford', 'Model A', 1994, 1, 4, NULL, 'Good', 1)
	,('PLN 0002', 'Tesla', 'Model B', 2021, 2, 4, NULL, 'Great', 1)
	,('PLN 0003', 'Capsule Corp', 'Model C', 2054, 3, 10, NULL, 'Best', 0)

INSERT INTO Employees VALUES
	('Tyler', 'Durden', 'Edward Norton`s Alter Ego', NULL)
	,('Plain', 'Jane', 'some gal', NULL)
	,('Average', 'Joe', 'some dude', NULL)

INSERT INTO Customers VALUES
	('123456', 'Jimmy Carr', 'Britain', 'London', 1000, NULL)
	,('654321', 'Bill Burr', 'USA', 'Washington', 2000, NULL)
	,('999999', 'Louis CK', 'Mexico', 'Mexico City', 3000, NULL)

INSERT INTO RentalOrders VALUES
	(1, 1, 1, 70, 90000, 100000, 10000, '1994-10-01', '1994-10-21', 20, 100.00, 14.00, 'Pending', NULL)
	,(2, 2, 2, 85, 250000, 2750000, 25000, '2011-11-12', '2011-11-24', 12, 150.00, 17.50, 'Canceled', NULL)
	,(3, 3, 3, 90, 0, 120000, 120000, '2025-04-05', '2025-05-02', 27, 220.00, 21.25, 'Delivered', NULL)



--15
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY
	,FirstName VARCHAR(50) NOT NULL
	,LastName VARCHAR(50) NOT NULL
	,Title VARCHAR(50) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY IDENTITY
	,FirstName VARCHAR(50) NOT NULL
	,LastName VARCHAR(50) NOT NULL
	,PhoneNumber INT NOT NULL
	,EmergencyName VARCHAR(50)
	,EmergencyNumber INT
	,Notes NVARCHAR(1000)
)

CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(50) PRIMARY KEY NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(50) PRIMARY KEY NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE BedTypes
(
	BedType VARCHAR(50) PRIMARY KEY NOT NULL
	,Notes NVARCHAR(1000)
)


CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY IDENTITY
	,RoomType VARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL
	,BedType VARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL
	,Rate DECIMAL(5,2) NOT NULL
	,RoomStatus VARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY
	,EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
	,PaymentDate DATE NOT NULL
	,AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL
	,FirstDateOccupied DATE NOT NULL
	,LastDateOccupied DATE NOT NULL
	,TotalDays INT NOT NULL
	,AmountCharged DECIMAL(6, 2) NOT NULL
	,TaxRate DECIMAL(4, 2) NOT NULL
	,TaxAmount DECIMAL(6, 2) NOT NULL
	,PaymentTotal DECIMAL(6, 2) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY
	,EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
	,DateOccupied DATE NOT NULL
	,AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL
	,RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL
	,RateApplied DECIMAL(4, 2) NOT NULL
	,PhoneCharge DECIMAL(4, 2) NOT NULL
	,Notes NVARCHAR(1000)
)

INSERT INTO Employees VALUES
	('Jim', 'McJim', 'Supervisor', NULL)
	,('Jane', 'McJane', 'Cook', NULL)
	,('John', 'McJohn', 'Waiter', NULL)

INSERT INTO [Customers] VALUES
	('Mickey', 'Mouse', 12345678, 'Minnie', 11111111, NULL)
	,('Donald', 'Duck', 87654321, 'Daisy', 22222222, NULL)
	,('Scrooge', 'McDuck', 9999999, 'Richie', 33333333, NULL)

INSERT INTO [RoomStatus] VALUES
	('Free', NULL)
	,('Occupied', NULL)
	,('No idea', NULL)

INSERT INTO [RoomTypes] VALUES
	('Room', NULL)
	,('Studio', NULL)
	,('Apartment', NULL)

INSERT INTO [BedTypes] VALUES
	('Big', NULL)
	,('Small', NULL)
	,('Child', NULL)

INSERT INTO [Rooms] VALUES
	('Room', 'Big', 15.00, 'Free', NULL)
	,('Studio', 'Small', 12.50, 'Occupied', NULL)
	,('Apartment', 'Child', 10.25, 'No idea', NULL)

INSERT INTO [Payments] VALUES
	(1, '2023-02-01', 1, '2023-01-11', '2023-01-14', 3, 250.00, 20.00, 50.00, 300.00, NULL)
	,(2, '2023-02-02', 2, '2023-01-12', '2023-01-15', 3, 199.90, 20.00, 39.98, 239.88, NULL)
	,(3, '2023-02-03', 3, '2023-01-13', '2023-01-16', 3, 330.50, 20.00, 66.10, 396.60, NULL)

INSERT INTO [Occupancies] VALUES
	(1, '2023-01-01', 1, 1, 20.00, 15.00, NULL)
	,(2, '2023-01-02', 2, 2, 20.00, 12.50, NULL)
	,(3, '2023-01-03', 3, 3, 20.00, 18.90, NULL)

--19
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--20
SELECT * FROM Towns
	ORDER BY Name

SELECT * FROM Departments
	ORDER BY Name

SELECT * FROM Employees
	ORDER BY Salary DESC

--21
SELECT [Name] FROM Towns
	ORDER BY [Name]

SELECT [Name] FROM Departments
	ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
	ORDER BY Salary DESC

--22
UPDATE Employees
	SET Salary *= 1.1

SELECT Salary FROM Employees

--23
UPDATE Payments
	SET TaxRate -= 0.03

SELECT TaxRate FROM Payments

--24
DELETE Occupancies








