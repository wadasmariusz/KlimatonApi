﻿using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ThreatMap.Admin.Extensions
{
    public static class HtmlHelperExtensions
    {
        //public static IHtmlContent DisplayOrNoData(this IHtmlHelper htmlHelper, string html)
        //{
        //    if (html == null)
        //        return new HtmlString("<span class=\"kt-font-danger\">brak danych</span>");

        //    return new HtmlString(html);

        //}

        //public static IHtmlContent LinkOrNoData(this IHtmlHelper htmlHelper, string html)
        //{
        //    if (html == null)
        //        return new HtmlString("<span class=\"kt-font-danger\">brak danych</span>");

        //    return new HtmlString("<a href=" + html + " target=\"_blank\">" + html + "</a>");
        //}

        private const string _partialViewScriptItemPrefix = "scripts_";
        public static IHtmlContent PartialSectionScripts(this IHtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            htmlHelper.ViewContext.HttpContext.Items[_partialViewScriptItemPrefix + Guid.NewGuid()] = template;
            return new HtmlContentBuilder();
        }
        public static IHtmlContent RenderPartialSectionScripts(this IHtmlHelper htmlHelper)
        {
            var partialSectionScripts = htmlHelper.ViewContext.HttpContext.Items.Keys
                .Where(k => Regex.IsMatch(
                    k.ToString(),
                    "^" + _partialViewScriptItemPrefix + "([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$"));
            var contentBuilder = new HtmlContentBuilder();
            foreach (var key in partialSectionScripts)
            {
                var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
                if (template != null)
                {
                    var writer = new System.IO.StringWriter();
                    template(null).WriteTo(writer, HtmlEncoder.Default);
                    contentBuilder.AppendHtml(writer.ToString());
                }
            }
            return contentBuilder;
        }
    }
}