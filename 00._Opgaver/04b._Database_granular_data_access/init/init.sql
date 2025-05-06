-- Create DB and switch
CREATE DATABASE SampleDB;
GO
USE SampleDB;
GO

-- Create 4 tables
CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50),
    Salary INT,
    Department NVARCHAR(50)
);
CREATE TABLE Products (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50),
    Cost INT,
    Category NVARCHAR(50)
);
CREATE TABLE Orders (
    Id INT PRIMARY KEY,
    ProductId INT,
    Quantity INT,
    Customer NVARCHAR(50)
);
CREATE TABLE Customers (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50),
    Email NVARCHAR(100)
);

-- Insert sample data
INSERT INTO Employees VALUES (1, 'Alice', 90000, 'HR'), (2, 'Bob', 120000, 'Engineering');
INSERT INTO Products VALUES (1, 'Widget', 50, 'Tools'), (2, 'Gadget', 100, 'Electronics');
INSERT INTO Orders VALUES (1, 1, 10, 'CustomerA'), (2, 2, 5, 'CustomerB');
INSERT INTO Customers VALUES (1, 'CustomerA', 'a@example.com'), (2, 'CustomerB', 'b@example.com');

-- ✅ Separate batch before CREATE SCHEMA
GO
CREATE SCHEMA Security;
GO

-- Create the row-level security function
CREATE FUNCTION Security.fn_row_filter_orders(@Customer NVARCHAR(50))
RETURNS TABLE
WITH SCHEMABINDING
AS
RETURN SELECT 1 AS fn_result WHERE @Customer = 'CustomerA';
GO

-- Apply the row-level security policy
CREATE SECURITY POLICY Security.OrderFilterPolicy
ADD FILTER PREDICATE Security.fn_row_filter_orders(Customer) ON dbo.Orders
WITH (STATE = ON);
GO

-- Create the limited access user
CREATE LOGIN public_user WITH PASSWORD = 'PublicUser123!';
CREATE USER public_user FOR LOGIN public_user;

-- Column-level permissions: Grant only selected columns
GRANT SELECT (Id, Name) ON Employees TO public_user;
GRANT SELECT (Name, Category) ON Products TO public_user;

-- Row-level permission on Orders (already applied via the security policy)
GRANT SELECT ON Orders TO public_user;
GRANT SELECT ON Customers TO public_user;
GO
