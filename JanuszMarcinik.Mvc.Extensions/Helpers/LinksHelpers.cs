using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.Extensions.Helpers
{
    public static class LinksHelpers
    {
        public static MvcHtmlString SubmitLink(this HtmlHelper html, string text, string formId)
        {
            var tag = new TagBuilder("a");

            tag.MergeAttribute("href", string.Format("javascript: document.getElementById('{0}').submit()", formId));
            tag.InnerHtml = text;

            return MvcHtmlString.Create(tag.ToString());
        }
    }
}