CREATE TABLE [dbo].[LogException]
(
	[LogExceptionId] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [ExceptionPath] NVARCHAR(100) NOT NULL, 
    [When] DATETIME NOT NULL, 
    [ExceptionMessage] NVARCHAR(max) NOT NULL 
)