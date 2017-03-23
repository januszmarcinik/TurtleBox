using TwitterBootstrapMVC;
using TwitterBootstrapMVC.Controls;

namespace JanuszMarcinik.Mvc.Extensions.Helpers
{
    public static class InputsHelper
    {
        #region DatePicker()
        public static BootstrapControlGroupTextBox<TModel> DatePicker<TModel>(this BootstrapControlGroupTextBox<TModel> textbox) where TModel : class
        {
            var attr = new { toggle = "date" };
            var icon = new Icon(FontAwesome.calendar);

            textbox.Data(attr).AppendIcon(icon).Format("{0:yyyy-MM-dd}");

            return textbox;
        }
        #endregion

        #region DateTimePicker()
        public static BootstrapControlGroupTextBox<TModel> DateTimePicker<TModel>(this BootstrapControlGroupTextBox<TModel> textbox) where TModel : class
        {
            var attr = new { toggle = "datetime" };
            var icon = new Icon(FontAwesome.calendar);

            textbox.Data(attr).AppendIcon(icon).Format("{0:yyyy-MM-dd HH:mm}");

            return textbox;
        }
        #endregion
    }
}