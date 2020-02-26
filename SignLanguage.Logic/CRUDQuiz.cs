using Microsoft.EntityFrameworkCore;
using SignLanguage.ADO;
using SignLanguage.Models;
using SignLanguage.Models.Models;
using SignLanguage.Models.Models.QuizToDisplayOnView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignLanguage.Logic
{
    public class CRUDQuiz
    {
        private static readonly Random getrandom = new Random();
        //Try use EF tools to get data from procedure
        // I had problems when i want do it
        public static List<StartQuiz> GetDataToStartQuiz(List<SpModel> dataToStartQuiz)
        {
            List<StartQuiz> finalDataToStartGame = new List<StartQuiz>();
            List<int> randomId = new List<int>();

            do
            {
                int randomNumber = getrandom.Next(0, dataToStartQuiz.Count);

                if (!randomId.Contains(randomNumber))
                {
                    var data = GetThreeRandomBadMeaningToGoodMeaning(dataToStartQuiz[randomNumber].IdGoodMeaningWord).Result;

                    List<CorrectWord> aaa = new List<CorrectWord>();
                    List<StartQuiz> prepareData = new List<StartQuiz>();
                    prepareData.Add(new StartQuiz("", new List<CorrectWord>()));

                    prepareData = AddGoodAnswer(prepareData, dataToStartQuiz[randomNumber]);
                    prepareData =  AddBadAnswers(prepareData, data);
                    prepareData[0].WordsToDisplay = ShuffleList(prepareData[0].WordsToDisplay);

                    finalDataToStartGame.AddRange(prepareData);

                    randomId.Add(randomNumber);
                }
            } while (finalDataToStartGame.Count <= 9);

            return finalDataToStartGame;
        }

        public static List<SpModel> HowManyAreBadMeaningToEachGoodMeaning()
        {
            return HowManyAreBadMeaningToEachGoodMeaningAsync().Result;
        }

        public static void  saveScoreQuizzes(UsersScoreQuiz saveScoreQuiz)
        {
            using (var context = new SignlanguageDatabaseContext())
            {
                context.UsersScoreQuiz.Add(saveScoreQuiz);
                context.SaveChanges();
            }
        }

        #region private method

        private static async Task<List<SpModel>> HowManyAreBadMeaningToEachGoodMeaningAsync()
        {
            using (var context = new SignlanguageDatabaseContext())
            {
                List<SpModel> result = await context.Query<SpModel>()
                    .AsNoTracking()
                    .FromSql(string.Format("EXECUTE GetIdWithMoreThan3BadMeaning"))
                    .ToListAsync();

                return result;
            }
        }

        private static async Task<List<Quiz>> GetThreeRandomBadMeaningToGoodMeaning(int idGoodMeaning)
        {
            string CommandText = "EXECUTE StartQuiz " + idGoodMeaning;

            using (var context = new SignlanguageDatabaseContext())
            {
                List<Quiz> result = await context.Query<Quiz>()
                    .AsNoTracking()
                    .FromSql(string.Format("EXECUTE StartQuiz " + idGoodMeaning.ToString()))
                    .ToListAsync();

                return result;
            }
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

        private static List<StartQuiz> AddBadAnswers(List<StartQuiz> prepareData, List<Quiz> data)
        {
            List<CorrectWord> correctWord = new List<CorrectWord>();
            foreach (var item in data)
            {
                correctWord.Add(
                    new CorrectWord
                    {
                        IsCorrect = false
                        ,
                        Meaning = item.Meaning
                    });
            }
            prepareData[0].WordsToDisplay.AddRange(correctWord);

            return prepareData;
        }

        private static List<StartQuiz> AddGoodAnswer(List<StartQuiz> prepareData, SpModel changeNameLate)
        {
            CorrectWord correctWord = new CorrectWord();
            correctWord.IsCorrect = true;
            correctWord.Meaning = changeNameLate.GoodMeaning;

            prepareData[0].url = changeNameLate.Url;
            prepareData[0].WordsToDisplay.Add(correctWord);

            return prepareData;
        }

        #endregion

    }
}
