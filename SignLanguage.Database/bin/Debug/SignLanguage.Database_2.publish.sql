﻿/*
Deployment script for SignLanguage.Database

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SignLanguage.Database"
:setvar DefaultFilePrefix "SignLanguage.Database"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key a44d2a4f-f9a2-41c7-b315-56723b93b0da is skipped, element [dbo].[Users].[Password] (SqlSimpleColumn) will not be renamed to Login';


GO
PRINT N'Rename refactoring operation with key 6be55942-3831-4e54-beeb-67ec7e42172f is skipped, element [dbo].[GoodMeaningWords].[Id] (SqlSimpleColumn) will not be renamed to IdGoodMeaningWord';


GO
PRINT N'Rename refactoring operation with key b313f5f4-dc22-4c9c-b02f-a42dbaeebd04 is skipped, element [dbo].[BadMeaningWords].[Id] (SqlSimpleColumn) will not be renamed to IdBadMeaningWord';


GO
PRINT N'Rename refactoring operation with key 2f4c2edb-67d9-4f08-91cc-965e3aea65f2 is skipped, element [dbo].[Users].[UserType] (SqlSimpleColumn) will not be renamed to UserRole';


GO
PRINT N'Creating [dbo].[BadMeaningWords]...';


GO
CREATE TABLE [dbo].[BadMeaningWords] (
    [IdBadMeaningWord]  INT           IDENTITY (1, 1) NOT NULL,
    [IdGoodMeaningWord] INT           NOT NULL,
    [Meaning]           NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdBadMeaningWord] ASC)
);


GO
PRINT N'Creating [dbo].[GoodMeaningWords]...';


GO
CREATE TABLE [dbo].[GoodMeaningWords] (
    [IdGoodMeaningWord] INT           IDENTITY (1, 1) NOT NULL,
    [Meaning]           NVARCHAR (50) NOT NULL,
    [Url]               NCHAR (300)   NOT NULL,
    PRIMARY KEY CLUSTERED ([IdGoodMeaningWord] ASC)
);


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [IdUser]              NVARCHAR (150) NOT NULL,
    [Login]               NVARCHAR (50)  NOT NULL,
    [PasswordExpiredDate] DATETIME       NOT NULL,
    [UserRole]            SMALLINT       NOT NULL,
    [Email]               NCHAR (100)    NOT NULL,
    [EmailConfirmed]      BIT            NOT NULL,
    [Password]            NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUser] ASC)
);


GO
PRINT N'Creating [dbo].[DeleteBadMeaningWord]...';


GO
CREATE PROCEDURE [dbo].[DeleteBadMeaningWord]
	@IdBadMeaningWord int
AS
BEGIN
	
	DELETE BadMeaningWords 
    WHERE IdBadMeaningWord = @IdBadMeaningWord

END
GO
PRINT N'Creating [dbo].[DeleteGoodMeaningWords]...';


GO
CREATE PROCEDURE [dbo].[DeleteGoodMeaningWords]
	@IdGoodMeaningWord int
AS
BEGIN
	
	DELETE GoodMeaningWords 
    WHERE IdGoodMeaningWord = @IdGoodMeaningWord

END
GO
PRINT N'Creating [dbo].[GetIdWithMoreThan3BadMeaning]...';


GO
Create PROCEDURE [dbo].[GetIdWithMoreThan3BadMeaning]
AS
BEGIN

Select Count(*) as HowManyBadMeaning, BMW.IdGoodMeaningWord, Url
from BadMeaningWords BMW 
INNER JOIN GoodMeaningWords GMW ON BMW.IdGoodMeaningWord = GMW.IdGoodMeaningWord
group by BMW.IdGoodMeaningWord, Url

END
GO
PRINT N'Creating [dbo].[InsertBadMeaningWord]...';


GO
CREATE PROCEDURE [dbo].[InsertBadMeaningWord]
	@IdGoodMeaningWord int = 0
	, @Meaning nvarchar(30)
AS
BEGIN 

     INSERT INTO BadMeaningWords
          (                    
            IdGoodMeaningWord        
            ,Meaning						    
          ) 
     VALUES 
          ( 
            @IdGoodMeaningWord
            ,@Meaning                   
          ) 

END
GO
PRINT N'Creating [dbo].[InsertGoodMeaningWords]...';


GO
CREATE PROCEDURE [dbo].[InsertGoodMeaningWords]
	@Meaning int,
	@Url nvarchar(300)
AS
BEGIN 

INSERT INTO GoodMeaningWords
          (                    
            Meaning
			,Url
          ) 
     VALUES 
          ( 
            @Meaning
			, @Url
          ) 

END
GO
PRINT N'Creating [dbo].[InsertUser]...';


GO
CREATE PROCEDURE [dbo].[InsertUser]
	@IdUser int = 0
	, @Login nvarchar(50)
	, @PasswordExpiredDate datetime
	, @UserRole smallint
	, @Email nchar
	, @EmailConfirmed bit
	, @Password nvarchar(50)
AS
BEGIN 

INSERT INTO Users
          (                    
            IdUser
			,Login
			, PasswordExpiredDate
			, UserRole
			, Email
			, EmailConfirmed
			, Password
          ) 
     VALUES 
          ( 
            @IdUser
			, @Login
			, @PasswordExpiredDate
			, @UserRole
			, @Email
			, @EmailConfirmed
			, @Password
          ) 

END
GO
PRINT N'Creating [dbo].[StartQuiz]...';


GO
CREATE PROCEDURE [dbo].[StartQuiz]
	@IdGoodMeaningWords int 
AS
BEGIN
IF (Select Count(*) from BadMeaningWords BMW Where  BMW.IdGoodMeaningWord = @IdGoodMeaningWords) >= 3
	BEGIN

	SELECT TOP 4 * 
	FROM 
        (
            SELECT GMW.IdGoodMeaningWord, GMW.Meaning, GMW.Url, NULL AS 'IdBadMeaning'  
			from GoodMeaningWords GMW
            Where  GMW.IdGoodMeaningWord = @IdGoodMeaningWords

			UNION ALL 

            Select BMW.IdGoodMeaningWord, BMW.Meaning, NULL, BMW.IdBadMeaningWord AS 'IdBadMeaning' 
			from BadMeaningWords BMW
			Where  BMW.IdGoodMeaningWord = @IdGoodMeaningWords
        ) dum
	order by NEWID()

	END
END
GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a44d2a4f-f9a2-41c7-b315-56723b93b0da')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a44d2a4f-f9a2-41c7-b315-56723b93b0da')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6be55942-3831-4e54-beeb-67ec7e42172f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6be55942-3831-4e54-beeb-67ec7e42172f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b313f5f4-dc22-4c9c-b02f-a42dbaeebd04')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b313f5f4-dc22-4c9c-b02f-a42dbaeebd04')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '2f4c2edb-67d9-4f08-91cc-965e3aea65f2')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('2f4c2edb-67d9-4f08-91cc-965e3aea65f2')

GO

GO
PRINT N'Update complete.';


GO
