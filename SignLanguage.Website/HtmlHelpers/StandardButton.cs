using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignLanguage.Website.HtmlHelpers
{
    public static class StandardButton
    {
        #region Extensions to html

        public static HtmlString InputAdd(this IHtmlHelper htmlHelper)
        {
            //TODO Try later use TagBuilder to build own HTML extesions
            StringBuilder generateInput = CreateInputWithDifreentValueWithTheSameOthersHTML("Dodaj");

            return new HtmlString(generateInput.ToString());
        }

        public static HtmlString InputLogin(this IHtmlHelper htmlHelper)
        {
            //TODO Try later use TagBuilder to build own HTML extesions
            StringBuilder generateInput = CreateInputWithDifreentValueWithTheSameOthersHTML("Zaloguj");

            return new HtmlString(generateInput.ToString());
        }

        public static HtmlString InputRegister(this IHtmlHelper htmlHelper)
        {
            //TODO Try later use TagBuilder to build own HTML extesions
            StringBuilder generateInput = CreateInputWithDifreentValueWithTheSameOthersHTML("Zajestruj");

            return new HtmlString(generateInput.ToString());
        }
        public static HtmlString InputDelete(this IHtmlHelper htmlHelper)
        {
            //TODO Try later use TagBuilder to build own HTML extesions
            StringBuilder generateInput = CreateInputWithDifreentValueWithTheSameOthersHTML("Usuń");

            return new HtmlString(generateInput.ToString());
        }

        #endregion

        #region Private methods helper

        private static StringBuilder CreateInputWithDifreentValueWithTheSameOthersHTML(string valueInput)
        {
            StringBuilder generateInput = new StringBuilder();
            generateInput.AppendLine("<div class= 'form-group'>");
            generateInput.AppendLine("<div class= 'col-md-10 col-md-offset-2'>");
            generateInput.AppendLine("<input type='submit' value='" + valueInput + "' class='btn btn-default' />");
            generateInput.AppendLine("</div>");
            generateInput.AppendLine("</div>");
            return generateInput;
        }

        #endregion
    }
}
