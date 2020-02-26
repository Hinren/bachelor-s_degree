CREATE PROCEDURE [dbo].[GetIdWithMoreThan3BadMeaning]

AS
BEGIN

	Select Count(BMW.IdBadMeaningWord) as HowManyBadMeaning, BMW.IdGoodMeaningWord, Url, GMW.Meaning as GoodMeaning
	from BadMeaningWords BMW 
	INNER JOIN GoodMeaningWords GMW ON BMW.IdGoodMeaningWord = GMW.IdGoodMeaningWord
	group by BMW.IdGoodMeaningWord, Url, GMW.Meaning
	Having Count(BMW.IdBadMeaningWord) > 2

END
