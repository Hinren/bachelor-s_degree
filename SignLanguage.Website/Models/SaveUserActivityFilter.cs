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

        public  void OnActionExecuted(ActionExecutedContext actionExecutingContex)
        {
            if (actionExecutingContex.HttpContext.User.Identity.IsAuthenticated)
            {
                ActivityOnWebsite activityOnWebsite = new ActivityOnWebsite();

                activityOnWebsite.Userid = GetUserId(actionExecutingContex.HttpContext.User.Identity.Name).Result;
                activityOnWebsite.Controller = (string)actionExecutingContex.RouteData.Values["Controller"];
                activityOnWebsite.ActionName = (string)actionExecutingContex.RouteData.Values["Action"];
                activityOnWebsite.httpTypeAction = actionExecutingContex.HttpContext.Request.Method;
                activityOnWebsite.When = DateTime.Now;

                databaseContex.ActivityOnWebsite.Add(activityOnWebsite);
                databaseContex.SaveChanges();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public async Task<string> GetUserId(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return user.UserId;
        }
    }
}
