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
