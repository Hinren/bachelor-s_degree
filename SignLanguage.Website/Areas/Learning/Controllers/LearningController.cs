﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignLanguage.EF;
using SignLanguage.EF.Repository;
using SignLanguage.Logic;
using SignLanguage.Website.Controllers;

namespace SignLanguage.Website.Areas.Learning.Controllers
{
    [Area("Learning")]
    public class LearningController : BaseController
    {
        private readonly UnitOfWork unitOfWork;

        public LearningController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Learn(int page = 1)
        {
            var goodMeaningWords = unitOfWork.GoodMeaningWordsRepository.GetPaged(page, 10);
            return View(goodMeaningWords);
        }
    }
}