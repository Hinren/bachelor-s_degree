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
