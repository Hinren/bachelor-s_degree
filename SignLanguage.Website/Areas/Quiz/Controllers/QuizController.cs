using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignLanguage.ADO;
using SignLanguage.Logic;
using SignLanguage.Models;
using SignLanguage.Models.Models;
using SignLanguage.Website.Controllers;

namespace SignLanguage.Website.Areas.Quiz.Controllers
{
    [Area("Quiz")]
    public class QuizController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<SpModel> quizData = CRUDQuiz.HowManyAreBadMeaningToEachGoodMeaning();
            if (quizData.Count > 10)
            {
                var finalData = CRUDQuiz.GetDataToStartQuiz(quizData);
                return View(finalData);
            }
            else
            {
                SetMessageInfo("Nie ma wystarczająco dużo danych by rozpocząć quiz");
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Index(string scoreButton)
        {
            UsersScoreQuiz saveScoreQuiz = new UsersScoreQuiz();
            saveScoreQuiz.HowManyQustion = 10;
            saveScoreQuiz.IdUser = StaticUser.IdUser;
            saveScoreQuiz.EffectivenessInPercent = decimal.Parse(scoreButton) / 10;

            CRUDQuiz.saveScoreQuizzes(saveScoreQuiz);

            return RedirectToAction("Index");
        }
    }
}