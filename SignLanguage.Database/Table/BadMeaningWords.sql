CREATE TABLE [dbo].[BadMeaningWords]
(
	[IdBadMeaningWord] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [IdGoodMeaningWord] INT NOT NULL, 
    [Meaning] NVARCHAR(50) NOT NULL
)
