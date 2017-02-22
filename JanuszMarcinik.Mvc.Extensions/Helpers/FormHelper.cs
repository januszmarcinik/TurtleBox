namespace JanuszMarcinik.Mvc.Extensions.Helpers
{
    public static class FormHelper
    {
        public static TwitterBootstrapMVC.Form Upload(this TwitterBootstrapMVC.Form form)
        {
            return form.HtmlAttributes(new { enctype = "multipart/form-data" });
        }
    }
}