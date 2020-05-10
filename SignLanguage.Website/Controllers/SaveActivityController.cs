using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignLanguage.EF;

namespace SignLanguage.Website.Controllers
{
    public class SaveActivityController : BaseController
    {
        private readonly UnitOfWork unitOfWork;

        public SaveActivityController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

    }
}