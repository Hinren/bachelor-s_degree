CREATE TABLE [dbo].[UsersScoreQuiz]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[IdUser] NVARCHAR(150) NOT NULL,
	[HowManyQustion] int NOT NULL, 
    [EffectivenessInPercent] DECIMAL(3, 2) NOT NULL
)
