using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using SignLanguage.EF;
using SignLanguage.EF.Models;
using SignLanguage.EF.Repository;

namespace SignLanguage.Website.Controllers
{
    public class ErrorController : BaseController
    {
        private UnitOfWork databaseContex;

        public ErrorController(UnitOfWork databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        [Microsoft.AspNetCore.Mvc.Route("Error")]
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
                databaseContex.LogExceptionRepository.Add(logException);

                databaseContex.SaveChanges();
            }
            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;

            return View("Error");
        }
    }
}