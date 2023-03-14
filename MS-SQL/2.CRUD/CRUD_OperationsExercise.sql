USE SoftUni
GO

--2
SELECT * FROM Departments

--3
SELECT Name FROM Departments

--4
SELECT FirstName,LastName,Salary FROM Employees

--5
SELECT FirstName,MiddleName,LastName FROM Employees

--6
SELECT CONCAT(FirstName,'.',LastName) + '@softuni.bg' as 'Full Email Address'
FROM Employees

--7
SELECT DISTINCT Salary
FROM Employees

--8
SELECT * FROM Employees
WHERE JobTitle = 'Sales RePresentative'

--9
SELECT FirstName,LastName,JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--10
SELECT CONCAT(FirstName,' ',MiddleName,' ',LastName) AS 'Full Name'
FROM Employees
WHERE Salary IN (25000,14000,12500,23600)

--11
SELECT FirstName,LastName
FROM Employees
WHERE ManagerID IS NULL

--12
SELECT FirstName,LastName,Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--13
SELECT TOP 5  FirstName,LastName
FROM Employees
ORDER BY Salary DESC

--14
SELECT FirstName,LastName
FROM Employees
WHERE DepartmentID NOT IN (4)

--15
SELECT * FROM Employees
ORDER BY Salary DESC,
	FirstName ASC,
	LastName DESC,
	MiddleName ASC

--16
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EmployeesSalariesn]'))
    CREATE VIEW [dbo].[V_EmployeesSalariesn] AS
    SELECT FirstName, LastName, Salary
    FROM Employees


--17
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EmployeeNameJobTitle]'))
	CREATE VIEW V_EmployeeNameJobTitle AS 
	SELECT CONCAT(FirstName,' ',ISNULL(MiddleName, ''),' ',LastName) AS 'Full Name', JobTitle
	FROM Employees



