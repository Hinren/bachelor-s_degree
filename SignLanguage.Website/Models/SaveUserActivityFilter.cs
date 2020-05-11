using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using SignLanguage.EF;
using SignLanguage.EF.Models;
using SignLanguage.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignLanguage.Website.Filter
{
    public class SaveUserActivityFilter : IActionFilter
    {
        private UnitOfWork databaseContex;
        private UserManager<ApplicationUser> userManager;

        public SaveUserActivityFilter(UnitOfWork databaseContex, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.databaseContex = databaseContex;
        }

        public async void OnActionExecuted(ActionExecutedContext actionExecutingContex)
        {
            if (actionExecutingContex.HttpContext.User.Identity.IsAuthenticated)
            {
                ActivityOnWebsite activityOnWebsite = new ActivityOnWebsite();
                ApplicationUser currentlyUser = await userManager.FindByNameAsync(actionExecutingContex.HttpContext.User.Identity.Name);

                activityOnWebsite.Userid = currentlyUser.UserId;
                activityOnWebsite.Controller = (string)actionExecutingContex.RouteData.Values["Controller"];
                activityOnWebsite.ActionName = (string)actionExecutingContex.RouteData.Values["Action"];
                activityOnWebsite.httpTypeAction = actionExecutingContex.HttpContext.Request.Method;
                activityOnWebsite.When = DateTime.Now;

                databaseContex.ActivityOnWebsite.Add(activityOnWebsite);
                databaseContex.SaveChanges();
                databaseContex.Dispose();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
