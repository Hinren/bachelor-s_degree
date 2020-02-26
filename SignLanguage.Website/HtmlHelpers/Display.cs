using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SignLanguage.Website.HtmlHelpers
{
    public static class Display
    {
        public static IHtmlContent DisplayImageOrVideoFor(this IHtmlHelper htmlHelper, string url, int numberElement)
        {

            var extn = url.Split(".").Last().Trim();
            if (extn == "png" || extn == "jpeg" || extn == "jpg")
            {
                var content = new HtmlContentBuilder()
                         .AppendHtml("<img class = 'col-lg-12' width = '420' height = '315' src = '" + url + " ' alt = 'Image' class='col-lg-12' style='border-radius: 8%; margin-top: 10px;' />");
                return content;
            }
            else
            {
                var content = new HtmlContentBuilder()
                         .AppendHtml("<iframe class = 'col-lg-12' width = '420' height = '315' src = '" + url + "' frameborder = '0' allow = 'autoplay; encrypted-media' allowfullscreen class='col-lg-12' style='margin-top: 10px; border-radius: 8%;'></iframe>");
                return content;
            }
        }
    }
}
