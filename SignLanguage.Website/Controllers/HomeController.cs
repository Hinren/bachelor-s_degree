using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignLanguage.Website.Models;

namespace SignLanguage.Website.Controllers
{
    public class HomeController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
