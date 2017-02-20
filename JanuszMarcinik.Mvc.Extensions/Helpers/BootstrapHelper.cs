using System.Web.Mvc;
using TwitterBootstrap3;
using TwitterBootstrapMVC.BootstrapMethods;
using TwitterBootstrapMVC.Controls;

namespace JanuszMarcinik.Mvc.Extensions.Helpers
{
    public static class BootstrapHelper
    {
        public static BootstrapActionLinkButton AddButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLinkButton("Dodaj", result).Style(ButtonStyle.Success).PrependIcon(FontAwesome.plus);
        }

        public static BootstrapActionLinkButton ListButton<TModel>(this BootstrapBase<TModel> bootstrap, string linkText, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLinkButton("", result).Title(linkText).PrependIcon(FontAwesome.list);
        }

        public static BootstrapActionLinkButton EditButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLinkButton("", result).Title("Edytuj").Style(ButtonStyle.Warning).PrependIcon(FontAwesome.pencil);
        }

        public static BootstrapActionLinkButton DeleteButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLinkButton("", result).Title("Usuń").Style(ButtonStyle.Danger).PrependIcon(FontAwesome.remove);
        }

        public static BootstrapActionLinkButton BackButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLinkButton("Powrót", result).PrependIcon(FontAwesome.arrow_left);
        }

        public static BootstrapButton<TModel> SubmitSaveButton<TModel>(this BootstrapBase<TModel> bootstrap) where TModel : class
        {
            return bootstrap.SubmitButton().Text("Zapisz").PrependIcon(FontAwesome.save).Style(ButtonStyle.Primary);
        }

        public static BootstrapButton<TModel> SubmitDeleteButton<TModel>(this BootstrapBase<TModel> bootstrap) where TModel : class
        {
            return bootstrap.SubmitButton().Text("Usuń").PrependIcon(FontAwesome.remove).Style(ButtonStyle.Danger);
        }
    }
}