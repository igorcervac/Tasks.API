USE [Subscription1DB]
GO

CREATE SCHEMA Tasks
GO

CREATE TABLE [Tasks].[States](Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [Name] NVARCHAR(256))
GO

INSERT INTO [Tasks].[States]([Name]) VALUES ('To Do'), ('In Progress'), ('Completed')

CREATE TABLE [Tasks].[Tasks](
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
[Title] NVARCHAR(1024) NULL, 
[Description] NVARCHAR(MAX) NULL, 
[StateId] INT NOT NULL, 
FOREIGN KEY([StateId]) REFERENCES  [Tasks].[States](Id))
GO