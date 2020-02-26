using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignLanguage.Website.HtmlHelpers
{
    public class DropDownList
    {
        /*private static MvcHtmlString DropDownPicker<TModel>(this HtmlHelper<TModel> htmlHelper, string name, object value, string action, string controller, string area, Func<object, string> getSelectedItemText, IDictionary<string, object> htmlAttributes)
        {
            string optionLabel = "Wybierz";

            List<SelectListItem> selectList = new List<SelectListItem>();

            if (value != null && value.ToString() != "0")
            {
                selectList.Add(new SelectListItem() { Value = string.Empty, Text = optionLabel, Selected = false });
                selectList.Add(new SelectListItem() { Value = value.ToString(), Text = getSelectedItemText(value), Selected = true });
            }

            if (htmlAttributes == null)
            {
                htmlAttributes = new Dictionary<string, object>();
            }
            htmlAttributes.Add("class", "form-control selectpicker");
            htmlAttributes.Add("data-actions-box", true);
            htmlAttributes.Add("data-live-search", true);
            htmlAttributes.Add("data-live-search-ajax", true);
            htmlAttributes.Add("data-live-search-ajax-url", new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(action, controller, new { Area = area }));
            htmlAttributes.Add("data-live-search-ajax-optionlabel", optionLabel);
            htmlAttributes.Add("title", optionLabel);

            return htmlHelper.DropDownList(name, selectList, htmlAttributes);
        }
        private static MvcHtmlString DropDownPickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string action, string controller, string area, Func<object, string> getSelectedItemText, IDictionary<string, object> htmlAttributes)
        {
            string optionLabel = "Wybierz";

            List<SelectListItem> selectList = new List<SelectListItem>();

            TProperty selectedValue = expression.Compile().Invoke(htmlHelper.ViewData.Model);
            if (selectedValue != null && selectedValue.ToString() != "0")
            {
                selectList.Add(new SelectListItem() { Value = string.Empty, Text = optionLabel, Selected = false });
                selectList.Add(new SelectListItem() { Value = selectedValue.ToString(), Text = getSelectedItemText(selectedValue), Selected = true });
            }

            if (htmlAttributes == null)
            {
                htmlAttributes = new Dictionary<string, object>();
            }
            if (htmlAttributes.ContainsKey("class"))
            {
                htmlAttributes["class"] += " form-control selectpicker";
            }
            else
            {
                htmlAttributes.Add("class", "form-control selectpicker");
            }
            htmlAttributes.Add("data-actions-box", true);
            htmlAttributes.Add("data-live-search", true);
            htmlAttributes.Add("data-live-search-ajax", true);
            htmlAttributes.Add("data-live-search-ajax-url", new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(action, controller, new { Area = area }));
            htmlAttributes.Add("data-live-search-ajax-optionlabel", optionLabel);
            htmlAttributes.Add("title", optionLabel);

            return htmlHelper.DropDownListFor(expression, selectList, htmlAttributes);
        }


        public static MvcHtmlString DropDownTypPojemnikaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string optionLabel)
        {
            return htmlHelper.DropDownTypPojemnikaFor(expression, optionLabel, null);
        }
        public static MvcHtmlString DropDownTypPojemnikaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.DropDownTypPojemnikaFor(expression, optionLabel, htmlAttributes, null);
        }
        public static MvcHtmlString DropDownTypPojemnikaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string optionLabel, IDictionary<string, object> htmlAttributes, SearchParamsDictionaries searchParams)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            IDicGospodarkaOdpadamiTypPojemnikaRepository repo = DependencyResolver.Current.GetService<IDicGospodarkaOdpadamiTypPojemnikaRepository>();

            int totalCount;
            foreach (var dicElem in repo.Search(searchParams, out totalCount))
            {
                selectList.Add(new SelectListItem() { Text = dicElem.Nazwa, Value = dicElem.DicGospodarkaOdpadamiTypPojemnikaId.ToString() });
            }
            return DropDownListFor(htmlHelper, expression, optionLabel, htmlAttributes, selectList);
        }

        public static MvcHtmlString DropDownZakresPowierzchniFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string optionLabel)
        {
            return htmlHelper.DropDownZakresPowierzchniFor(expression, optionLabel, null);
        }
        public static MvcHtmlString DropDownZakresPowierzchniFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.DropDownZakresPowierzchniFor(expression, optionLabel, htmlAttributes, null);
        }
        public static MvcHtmlString DropDownZakresPowierzchniFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string optionLabel, IDictionary<string, object> htmlAttributes, SearchParamsDictionaries searchParams)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            IDicGospodarkaOdpadamiZakresyPowierzchniRepository repo = DependencyResolver.Current.GetService<IDicGospodarkaOdpadamiZakresyPowierzchniRepository>();

            int totalCount;
            foreach (var dicElem in repo.Search(searchParams, out totalCount))
            {
                selectList.Add(new SelectListItem() { Text = dicElem.Nazwa, Value = dicElem.DicGospodarkaOdpadamiZakresyPowierzchniId.ToString() });
            }
            return DropDownListFor(htmlHelper, expression, optionLabel, htmlAttributes, selectList);
        } */
    }
}
