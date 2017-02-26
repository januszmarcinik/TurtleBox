using System.Web.Mvc;
using TwitterBootstrap3;
using TwitterBootstrapMVC.BootstrapMethods;
using TwitterBootstrapMVC.Controls;

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

        public static BootstrapActionLink ListGroupItem<TModel>(this BootstrapBase<TModel> bootstrap, string text, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLink(text, result).Class("list-group-item");
        }
    }
}