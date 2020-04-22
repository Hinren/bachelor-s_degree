using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignLanguage.EF;
using SignLanguage.Logic;
using SignLanguage.Website.Controllers;

namespace SignLanguage.Website.Areas.Learning.Controllers
{
    [Area("Learning")]
    public class LearningController : BaseController
    {
        private readonly SignLanguageContex context;

        public LearningController(SignLanguageContex context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Learn()
        {
            List<GoodMeaningWords> repoGoodMeaningWords = new List<GoodMeaningWords>();

            var goodMeaningWords = context.GoodMeaningWords.ToList();

            foreach (var word in goodMeaningWords)
            {
                repoGoodMeaningWords.Add(new GoodMeaningWords
                {
                    IdGoodMeaningWord = word.IdGoodMeaningWord,
                    Meaning = word.Meaning,
                    Url = word.Url
                });
            }

            return View(repoGoodMeaningWords);
        }
    }
}