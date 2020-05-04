using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SignLanguage.Website.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContex)
        {
            string name = (string)actionExecutingContex.RouteData.Values["Controller"];
            string action = (string)actionExecutingContex.RouteData.Values["Action"];
            string httpTypeAction = actionExecutingContex.HttpContext.Request.Method;
            //Save later to database all activity users on website
            
            base.OnActionExecuting(actionExecutingContex);
        }

        #region displaying messages

        protected void SetMessageDanger(string text)
        {
            SetMessageDanger(text, null);
        }
        protected void SetMessageDanger(string text, IEnumerable<string> additionalMessages)
        {
            SetMessage("MessageForUserDanger", text, additionalMessages);
        }
        protected void SetMessageInfo(string text)
        {
            SetMessageInfo(text, null);
        }
        protected void SetMessageInfo(string text, IEnumerable<string> additionalMessages)
        {
            SetMessage("MessageForUserInfo", text, additionalMessages);
        }
        protected void SetMessageSuccess(string text)
        {
            SetMessageSuccess(text, null);
        }
        protected void SetMessageSuccess(string text, IEnumerable<string> additionalMessages)
        {
            SetMessage("MessageForUserSuccess", text, additionalMessages);
        }
        protected void SetMessageWarning(string text)
        {
            SetMessageWarning(text, null);
        }
        protected void SetMessageWarning(string text, IEnumerable<string> additionalMessages)
        {
            SetMessage("MessageForUserWarning", text, additionalMessages);
        }
        private void SetMessage(string tempDataKey, string text, IEnumerable<string> additionalMessages)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(text);

            if (additionalMessages != null)
            {
                stringBuilder.AppendLine("<ul>");
                foreach (var message in additionalMessages)
                {
                    stringBuilder.AppendLine("<li>" + message + "</li>");
                }
                stringBuilder.AppendLine("</ul>");
            }

            TempData[tempDataKey] = stringBuilder.ToString();
        }

        #endregion
    }
}