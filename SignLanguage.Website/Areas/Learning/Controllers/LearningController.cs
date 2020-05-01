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
        private readonly SignLanguageContex databaseContext;

        public LearningController(SignLanguageContex databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet]
        public ActionResult Learn()
        {
            var goodMeaningWords = databaseContext.GoodMeaningWords.ToList();

            return View(goodMeaningWords);
        }
    }
}