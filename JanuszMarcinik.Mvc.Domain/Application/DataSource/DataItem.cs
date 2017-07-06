using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.Domain.Application.DataSource
{
    public class DataItem
    {
        public DataItem()
        {
            this.Values = new List<DataItemValue>();
        }

        public int PrimaryKeyId { get; set; }
        public string PrimaryKeyStringId { get; set; }

        public List<DataItemValue> Values { get; set; }
        public string ListText { get; set; }
        public ActionResult ListAction { get; set; }
        public ActionResult EditAction { get; set; }
        public ActionResult DeleteAction { get; set; }
    }

    public class DataItemValue
    {
        public DataItemValue(string value, bool isImage = false)
        {
            this.Value = value;
            this.IsImage = isImage;
        }

        public string Value { get; set; }
        public bool IsImage { get; set; }
        public ActionResult GetImageAction { get; set; }
    }
}