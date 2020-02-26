using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignLanguage.Logic;
using SignLanguage.Website.Controllers;

namespace SignLanguage.Website.Areas.Learning.Controllers
{
    [Area("Learning")]
    public class LearningController : BaseController
    {
        [HttpGet]
        public ActionResult Learn()
        {
            var data = GoodMeaningWordsCRUD.GetWordsToLearn();
            return View(data);
        }
    }
}