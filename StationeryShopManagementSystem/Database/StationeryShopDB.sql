-- ============================================================
-- StationeryShopDB.sql
-- Run this script in SQL Server Management Studio (SSMS)
-- to set up the database for the Stationery Shop Management System
-- ============================================================

-- Step 1: Create the database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'StationeryShopDB')
BEGIN
    CREATE DATABASE StationeryShopDB;
END
GO

USE StationeryShopDB;
GO

-- ============================================================
-- Step 2: Create the Categories table
-- ============================================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Categories' AND xtype='U')
BEGIN
    CREATE TABLE Categories
    (
        CategoryID   INT PRIMARY KEY IDENTITY(1,1),
        CategoryName NVARCHAR(100) NOT NULL
    );
END
GO

-- ============================================================
-- Step 3: Create the Suppliers table
-- ============================================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Suppliers' AND xtype='U')
BEGIN
    CREATE TABLE Suppliers
    (
        SupplierID   INT PRIMARY KEY IDENTITY(1,1),
        SupplierName NVARCHAR(100) NOT NULL,
        Phone        NVARCHAR(30),
        Email        NVARCHAR(100),
        Address      NVARCHAR(200)
    );
END
GO

-- ============================================================
-- Step 4: Create the Products table
-- Foreign keys reference Categories and Suppliers
-- ============================================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Products' AND xtype='U')
BEGIN
    CREATE TABLE Products
    (
        ProductID       INT PRIMARY KEY IDENTITY(1,1),
        ProductName     NVARCHAR(100) NOT NULL,
        CategoryID      INT NOT NULL,
        SupplierID      INT NOT NULL,
        UnitPrice       DECIMAL(10,2) NOT NULL,
        QuantityInStock INT NOT NULL,
        ReorderLevel    INT NOT NULL,

        CONSTRAINT FK_Products_Categories
            FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),

        CONSTRAINT FK_Products_Suppliers
            FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
    );
END
GO

-- ============================================================
-- Step 5: Insert sample Categories
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM Categories)
BEGIN
    INSERT INTO Categories (CategoryName) VALUES
        ('Writing'),
        ('Paper'),
        ('School Supplies'),
        ('Office Supplies'),
        ('Art Supplies');
END
GO

-- ============================================================
-- Step 6: Insert sample Suppliers
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM Suppliers)
BEGIN
    INSERT INTO Suppliers (SupplierName, Phone, Email, Address) VALUES
        ('ABC Stationery',  '01711-000001', 'abc@stationery.com',   'Dhaka, Bangladesh'),
        ('XYZ Traders',     '01711-000002', 'xyz@traders.com',      'Chittagong, Bangladesh'),
        ('Paper World',     '01711-000003', 'info@paperworld.com',  'Sylhet, Bangladesh'),
        ('Office Hub',      '01711-000004', 'hub@officehub.com',    'Rajshahi, Bangladesh'),
        ('Art Corner',      '01711-000005', 'art@corner.com',       'Khulna, Bangladesh');
END
GO

-- ============================================================
-- Step 7: Insert sample Products
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM Products)
BEGIN
    INSERT INTO Products (ProductName, CategoryID, SupplierID, UnitPrice, QuantityInStock, ReorderLevel) VALUES
        ('Ball Pen',     1, 1, 10.00,  100, 20),
        ('Gel Pen',      1, 1, 15.00,  80,  15),
        ('Pencil',       1, 1,  8.00,  120, 25),
        ('Notebook',     2, 2, 80.00,  50,  10),
        ('A4 Paper',     2, 3, 450.00, 25,   5),
        ('Eraser',       3, 1,  5.00,  100, 20),
        ('Ruler',        3, 4, 20.00,  60,  10),
        ('Marker',       4, 2, 50.00,  40,   8),
        ('Stapler',      4, 4, 150.00, 30,   5),
        ('Drawing Book', 5, 5, 120.00, 35,   7);
END
GO

-- ============================================================
-- Done! You can now open the project in Visual Studio and run it.
-- Make sure the connection string in DatabaseHelper.cs
-- matches your SQL Server instance name.
-- ============================================================
