

USE Pruthviraj;





SELECT * FROM Articles;

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Price DECIMAL(18, 2),
    Category NVARCHAR(50),
    Stock INT
);

select * from Products;

CREATE PROCEDURE [dbo].[AddProduct]
    @Name NVARCHAR(100),
    @Price DECIMAL(18, 2),
    @Category NVARCHAR(50),
    @Stock INT
AS
BEGIN
    INSERT INTO Products (Name, Price, Category, Stock)
    VALUES (@Name, @Price, @Category, @Stock);
END

EXEC GetProducts


CREATE PROCEDURE GetProducts
AS
BEGIN
    SELECT * FROM Products;  -- Replace with your actual table or logic
END


CREATE TABLE Employees
(
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Age INT,
    Position NVARCHAR(100) NOT NULL,
	Salary DECIMAL(18, 2)
);

select * from Employees



-- Stored Procedure: GetEmployeeById
CREATE PROCEDURE GetEmployeeById
    @EmployeeId INT
AS
BEGIN
    SELECT EmployeeId, Name, Position, Salary
    FROM Employees
    WHERE EmployeeId = @EmployeeId
END;

-- Stored Procedure: InsertEmployee
CREATE PROCEDURE InsertEmployee
    @Name NVARCHAR(100),
    @Position NVARCHAR(100),
    @Salary DECIMAL(18, 2),
    @Age INT
AS
BEGIN
    INSERT INTO Employees (Name, Position, Salary, Age)
    VALUES (@Name, @Position, @Salary, @Age)
END;



CREATE PROCEDURE UpdateEmployee
    @EmployeeId INT,
    @Name NVARCHAR(100),
    @Position NVARCHAR(100),
    @Salary DECIMAL(10, 2),
    @Age INT
AS
BEGIN
    UPDATE Employees
    SET 
        Name = @Name,
        Position = @Position,
        Salary = @Salary,
        Age = @Age
    WHERE EmployeeId = @EmployeeId;
END;


CREATE PROCEDURE DeleteEmployee
    @EmployeeId INT
AS
BEGIN
    DELETE FROM Employees
    WHERE EmployeeId = @EmployeeId;
END;


CREATE PROCEDURE GetAllEmployees
AS
BEGIN
    SELECT EmployeeId, Name, Position, Salary, Age
    FROM Employees;
END;
