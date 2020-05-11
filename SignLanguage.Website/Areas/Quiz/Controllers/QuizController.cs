using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignLanguage.EF;
using SignLanguage.Extension;
using SignLanguage.Logic;
using SignLanguage.Models;
using SignLanguage.Website.Areas.Quiz.Models;
using SignLanguage.Website.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace SignLanguage.Website.Areas.Quiz.Controllers
{
    [Area("Quiz")]
    public class QuizController : BaseController
    {
        private readonly UnitOfWork unitOfWork;

        public QuizController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var goodMeaningWords = unitOfWork.GoodMeaningWordsRepository.Get10RandomWordsThatHaveAtLeast3BadMeaning();

            var quizess = new List<QuizViewModel>();
            foreach (var goodMeaningWord in goodMeaningWords)
            {
                var quizData = new List<QuizData>();
                var select3RandomBadMeaning = goodMeaningWord.BadMeaningWords.Shuffle(3);
                
                foreach (var badMeaning in select3RandomBadMeaning)
                {
                    quizData.Add(
                        new QuizData 
                        { 
                            IsCorrect = false, 
                            Meaning = badMeaning.Meaning 
                        });
                }

                quizData.Add(
                    new QuizData 
                    { 
                        IsCorrect = true, 
                        Meaning = goodMeaningWord.Meaning 
                    });

                quizess.Add(
                    new QuizViewModel
                    {
                        Url = goodMeaningWord.Url,
                        Quizzes = quizData.Shuffle().ToList()
                    });
            }
            return View(quizess);
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