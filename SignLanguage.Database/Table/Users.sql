CREATE TABLE [dbo].[Users]
(
	[IdUser] NVARCHAR(150) NOT NULL PRIMARY KEY, 
    [Login] NVARCHAR(50) NOT NULL, 
    [PasswordExpiredDate] DATETIME NOT NULL, 
    [UserRole] SMALLINT NOT NULL, 
    [Email] NCHAR(100) NOT NULL, 
    [EmailConfirmed] BIT NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL
)
