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
        private readonly SignLanguageContex dbContext;

        public QuizController(SignLanguageContex dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<StartQuiz> badMeaningWords = new List<StartQuiz>();

            PrepareDataToStartQuiz prepareDataToStartQuiz = new PrepareDataToStartQuiz();

            var goodMeaningWords = dbContext.Query<GetIdWithMoreThan3BadMeaning>()
                .AsNoTracking()
                .FromSql(string.Format("EXECUTE GetIdWithMoreThan3BadMeaning")).ToList();

            foreach (var words in goodMeaningWords)
            {
                badMeaningWords.AddRange(dbContext.Query<StartQuiz>()
                    .AsNoTracking()
                    .FromSql(string.Format("EXECUTE StartQuiz " + words.IdGoodMeaningWord.ToString()))
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