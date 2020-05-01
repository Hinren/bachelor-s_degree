﻿/*
Deployment script for Sign.Database

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Sign.Database"
:setvar DefaultFilePrefix "Sign.Database"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\"

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
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


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
PRINT N'Creating [dbo].[UsersScoreQuiz]...';


GO
CREATE TABLE [dbo].[UsersScoreQuiz] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [IdUser]                 NVARCHAR (150) NOT NULL,
    [HowManyQustion]         INT            NOT NULL,
    [EffectivenessInPercent] DECIMAL (3, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[GetIdWithMoreThan3BadMeaning]...';


GO
CREATE PROCEDURE [dbo].[GetIdWithMoreThan3BadMeaning]

AS
BEGIN

	Select TOP 10 Count(BMW.IdBadMeaningWord) as HowManyBadMeaning, BMW.IdGoodMeaningWord, Url, GMW.Meaning as GoodMeaning
	from BadMeaningWords BMW 
	INNER JOIN GoodMeaningWords GMW ON BMW.IdGoodMeaningWord = GMW.IdGoodMeaningWord
	group by BMW.IdGoodMeaningWord, Url, GMW.Meaning
	Having Count(BMW.IdBadMeaningWord) > 2
	order by NEWID()

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

		Select TOP 3 BMW.IdGoodMeaningWord, BMW.Meaning, BMW.IdBadMeaningWord AS 'IdBadMeaning' 
		from BadMeaningWords BMW
		Where  BMW.IdGoodMeaningWord = @IdGoodMeaningWords
		order by NEWID()

	END
END
GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
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
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
