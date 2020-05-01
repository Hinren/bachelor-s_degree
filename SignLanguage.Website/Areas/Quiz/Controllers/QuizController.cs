using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignLanguage.EF;
using SignLanguage.Logic;
using SignLanguage.Website.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace SignLanguage.Website.Areas.Quiz.Controllers
{
    [Area("Quiz")]
    public class QuizController : BaseController
    {
        private readonly SignLanguageContex databaseContext;

        public QuizController(SignLanguageContex databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<StartQuiz> badMeaningWords = new List<StartQuiz>();

            PrepareDataToStartQuiz prepareDataToStartQuiz = new PrepareDataToStartQuiz();

            var goodMeaningWords = databaseContext.Query<GetIdWithMoreThan3BadMeaning>()
                .AsNoTracking()
                .FromSql(string.Format("EXECUTE GetIdWithMoreThan3BadMeaning")).ToList();

            foreach (var words in goodMeaningWords)
            {
                #pragma warning disable EF1000 // Possible SQL injection vulnerability.
                badMeaningWords.AddRange(databaseContext.Query<StartQuiz>()
                    .AsNoTracking()
                    .FromSql(string.Format("EXECUTE StartQuiz " + words.IdGoodMeaningWord.ToString()))
                #pragma warning restore EF1000 // Possible SQL injection vulnerability.
                    .ToList());
            }

            var finalData = prepareDataToStartQuiz.GetFinalData(badMeaningWords, goodMeaningWords);


           return View(finalData);
       }

       [HttpPost]
       public IActionResult Index(string scoreButton)
       {
           /* UsersScoreQuiz saveScoreQuiz = new UsersScoreQuiz();
            saveScoreQuiz.HowManyQustion = 10;
            saveScoreQuiz.IdUser = StaticUser.IdUser;
            saveScoreQuiz.EffectivenessInPercent = decimal.Parse(scoreButton) / 10;

            CRUDQuiz.saveScoreQuizzes(saveScoreQuiz);

            return RedirectToAction("Index");*/
            return View();
        }
    }
}