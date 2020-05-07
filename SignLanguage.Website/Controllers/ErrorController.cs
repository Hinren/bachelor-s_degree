using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SignLanguage.EF;
using SignLanguage.EF.Models;

namespace SignLanguage.Website.Controllers
{
    public class ErrorController : BaseController
    {
        private readonly SignLanguageContex databaseContex;

        public ErrorController(SignLanguageContex databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionDetails != null)
            {
                LogException logException = new LogException();
                logException.ExceptionPath = exceptionDetails.Path;
                logException.ExceptionMessage = exceptionDetails.Error.Message;
                logException.When = DateTime.Now;
                databaseContex.LogExceptions.Add(logException);

                databaseContex.SaveChanges();
            }
            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;

            return View("Error");
        }
    }
}