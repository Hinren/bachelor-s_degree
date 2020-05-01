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

        public List<QuizViewModel> GetFinalData(List<StartQuiz> badMeaningWords, List<GetIdWithMoreThan3BadMeaning> goodMeaningWords)
        {
            var quizViewModels = new List<QuizViewModel>();

            foreach (var goodMeaningWord in goodMeaningWords)
            {
                var quizzes = new List<Quiz>
                {
                    new Quiz
                    {
                        Meaning = goodMeaningWord.GoodMeaning
                        , IsCorrect = true
                    }
                };

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

        private static List<T> ShuffleList<T>(List<T> inputList)
        {
            var randomList = new List<T>();

            Random randomNumber = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = randomNumber.Next(0, inputList.Count); 
                randomList.Add(inputList[randomIndex]); 
                inputList.RemoveAt(randomIndex);
            }

            return randomList; 
        }
    }
}
