using Microsoft.EntityFrameworkCore;
using SignLanguage.EF;
using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SignLanguage.Logic
{
    public class PrepareDataToStartQuiz
    {
        private readonly SignLanguageContex dbContext;


        public List<QuizViewModel> GetFinalData(List<StartQuiz> badMeaningWords, List<GetIdWithMoreThan3BadMeaning> goodMeaningWords)
        {
            List<QuizViewModel> quizViewModels = new List<QuizViewModel>();

            foreach (var goodMeaningWord in goodMeaningWords)
            {
                List<Quiz> quizzes = new List<Quiz>();
                quizzes.Add(
                    new Quiz 
                    { 
                        Meaning = goodMeaningWord.GoodMeaning
                        , IsCorrect = true 
                    });

                var selectBadMeaningWordsToGoodMeaning = badMeaningWords
                    .Where(x => x.IdGoodMeaningWord == goodMeaningWord.IdGoodMeaningWord);

                foreach (var badWords in selectBadMeaningWordsToGoodMeaning)
                {
                    quizzes.Add(new Quiz
                    {
                        IsCorrect = false,
                        Meaning = badWords.Meaning
                    });
                }

                quizViewModels.Add(new QuizViewModel
                {
                    Url = goodMeaningWord.Url,
                    Quizzes = ShuffleList(quizzes)
                });
            }

            return quizViewModels;
        }

        private static List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }
    }
}
