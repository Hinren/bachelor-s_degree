using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignLanguage.ADO;


namespace SignLanguage.Website.Controllers
{
    public class BaseController : Controller
    {
        //public Users CurrentUser { get; set; }

        #region Wyświetlanie komunikatów
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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(text);


            if (additionalMessages != null)
            {
                sb.AppendLine("<ul>");
                foreach (var message in additionalMessages)
                {
                    sb.AppendLine("<li>" + message + "</li>");
                }
                sb.AppendLine("</ul>");
            }

            TempData[tempDataKey] = sb.ToString();
        }
        #endregion
    }
}