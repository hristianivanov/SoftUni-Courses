CREATE DATABASE [TableRelationsJAN2023]

GO 

USE TableRelationsJAN2023

GO


--1. One-To-One Relationship

CREATE TABLE [Passports]
(
	[PassportID] INT PRIMARY KEY IDENTITY(101,1)
	,[PassportNumber] VARCHAR(8) UNIQUE NOT NULL
)

CREATE TABLE [Persons]
(
	[PersonID] INT PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(50) NOT NULL
	,[Salary] DECIMAL(8,2) NOT NULL
	,[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE
)

--2. One-To-Many Relationship

CREATE TABLE [Manufacturers]
(
	[ManufacturerID] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,[EstablishedOn] DATETIME2 NOT NULL
)

CREATE TABLE [Models]
(
	[ModelID] INT PRIMARY KEY IDENTITY(101,1)
	,[Name] VARCHAR(50) NOT NULL
	,[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID]) NOT NULL
)

INSERT INTO [Manufacturers] ([Name],[EstablishedOn])
	VALUES
			('BMW','07/03/1916')
			,('Tesla','01/01/2003')
			,('Lada','01/05/1966')

INSERT INTO [Models] ([Name],[ManufacturerID])
	VALUES
			('X1',1)
			,('i6',1)
			,('Model S',2)
			,('Model X',2)
			,('Model 3',2)
			,('Nova',3)

--3. Many-To-Many Relationship\

CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Exams]
(
	[ExamID] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [StudentsExams]
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
	,[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID])
	PRIMARY KEY ([StudentID],[ExamID])
)


--4. Self-Referencing

CREATE TABLE [Teachers]
(
	[TeacherID] INT PRIMARY KEY IDENTITY(101, 1)
	,[Name] VARCHAR(50) NOT NULL
	,[ManagerID] INT FOREIGN KEY REFERENCES [Teachers](TeacherID)
)

INSERT INTO [Teachers]
	VALUES
		('John', NULL)
		,('Maya', 106)
		,('Silvia', 106)
		,('Ted', 105)
		,('Mark', 101)
		,('Greta', 101)

--5. Online Store Database

CREATE TABLE [Cities]
(
	[CityID] INT PRIMARY KEY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers]
(
	[CustomerID] INT PRIMARY KEY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,[Birthday] DATE NOT NULL
	,[CityID] INT FOREIGN KEY REFERENCES [Cities](CityID) NOT NULL
)

CREATE TABLE [Orders]
(
	[OrderID] INT PRIMARY KEY NOT NULL
	,[CustomerID] INT FOREIGN KEY REFERENCES [Customers](CustomerID) NOT NULL
)

CREATE TABLE [ItemTypes]
(
	[ItemTypeID] INT PRIMARY KEY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items]
(
	[ItemID] INT PRIMARY KEY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes](ItemTypeID) NOT NULL
)

CREATE TABLE [OrderItems]
(
	[OrderID] INT FOREIGN KEY REFERENCES [Orders](OrderID) NOT NULL
	,[ItemID] INT FOREIGN KEY REFERENCES [Items](ItemID) NOT NULL
	CONSTRAINT PK_OrderItems
		PRIMARY KEY (OrderID, ItemID)
)

--6. University Database

CREATE TABLE [Majors]
(
	[MajorID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Subjects]
(
	[SubjectID] INT PRIMARY KEY NOT NULL
	,[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY NOT NULL
	,[StudentNumber] INT NOT NULL
	,[StudentName] VARCHAR(50) NOT NULL
	,[MajorID] INT FOREIGN KEY REFERENCES [Majors](MajorID)
)

CREATE TABLE [Agenda]
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students](StudentID) NOT NULL
	,[SubjectID] INT FOREIGN KEY REFERENCES [Subjects](SubjectID)
	CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE [Payments]
(
	[PaymentID] INT PRIMARY KEY NOT NULL
	,[PaymentDate] DATETIME2 NOT NULL
	,[PaymentAmount] DECIMAL(6, 2)
	,[StudentID] INT FOREIGN KEY REFERENCES [Students](StudentID) NOT NULL
)

--9. *Peaks in Rila

USE [Geography]
GO

SELECT 
	m.MountainRange
	,p.PeakName
	,p.Elevation
	FROM Peaks AS p
		LEFT JOIN Mountains AS m
			ON p.MountainId = m.Id
		WHERE m.MountainRange = 'Rila'
		ORDER BY p.Elevation DESC