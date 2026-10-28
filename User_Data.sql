IF DB_ID(N'User_Data') IS NULL
    CREATE DATABASE [User_Data];
GO

USE [User_Data];
GO

IF OBJECT_ID(N'dbo.Roles', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Roles
    (
        ID int NOT NULL CONSTRAINT PK_Roles PRIMARY KEY,
        Name nvarchar(50) NULL
    );
END;
GO

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
        Login nvarchar(50) NULL,
        Password nvarchar(50) NULL,
        First_Name nvarchar(50) NULL,
        Second_Name nvarchar(50) NULL,
        Pictures nvarchar(max) NULL,
        RoleID int NULL,
        CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleID) REFERENCES dbo.Roles(ID)
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Roles WHERE ID = 1) INSERT dbo.Roles (ID, Name) VALUES (1, N'Manager');
IF NOT EXISTS (SELECT 1 FROM dbo.Roles WHERE ID = 2) INSERT dbo.Roles (ID, Name) VALUES (2, N'Seller');
IF NOT EXISTS (SELECT 1 FROM dbo.Roles WHERE ID = 3) INSERT dbo.Roles (ID, Name) VALUES (3, N'Director');
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Login = N'log1') INSERT dbo.Users (Login, Password, First_Name, Second_Name, Pictures, RoleID) VALUES (N'log1', N'pas1', N'Иван', N'Петров', N'1.png', 1);
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Login = N'log2') INSERT dbo.Users (Login, Password, First_Name, Second_Name, Pictures, RoleID) VALUES (N'log2', N'pas2', N'Денис', N'Иванов', N'2.png', 2);
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Login = N'log3') INSERT dbo.Users (Login, Password, First_Name, Second_Name, Pictures, RoleID) VALUES (N'log3', N'pas3', N'Светлана', N'Котова', N'3.png', 3);
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Login = N'log4') INSERT dbo.Users (Login, Password, First_Name, Second_Name, Pictures, RoleID) VALUES (N'log4', N'pas4', N'Кирилл', N'Сидоров', N'4.png', 2);
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Login = N'log5') INSERT dbo.Users (Login, Password, First_Name, Second_Name, Pictures, RoleID) VALUES (N'log5', N'pas5', N'Михаил', N'Семёнов', N'5.png', 1);
GO
