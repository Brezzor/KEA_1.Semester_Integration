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

-- Insert sample data
INSERT INTO Employees VALUES (1, 'Alice', 90000, 'HR'), (2, 'Bob', 120000, 'Engineering');
