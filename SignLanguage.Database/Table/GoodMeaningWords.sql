CREATE TABLE [dbo].[GoodMeaningWords]
(
	[IdGoodMeaningWord] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Meaning] NVARCHAR(50) NOT NULL, 
    [Url] NCHAR(300) NOT NULL
)
