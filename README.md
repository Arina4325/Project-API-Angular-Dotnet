
Data for users
DB Azure
SQL:
USE master
DROP DATABASE DotNetCourseDatabase

CREATE DATABASE DotNetCourseDatabase
GO
 
USE DotNetCourseDatabase
GO
CREATE SCHEMA TutorialAppSchema
GO
CREATE TABLE TutorialAppSchema.Users(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Age INT,
    UserRole NVARCHAR(50),
    Active BIT
);
GO
/* Incert*/
INSERT INTO TutorialAppSchema.Users(
    FirstName,
    LastName,
    Age,
    UserRole,
    Active
)VALUES ( 
    'Test',
    'Test',
    20,
    'User',
    1)
    GO
