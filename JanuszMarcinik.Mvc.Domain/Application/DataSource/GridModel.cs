using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.Domain.Application.DataSource
{
    public class GridModel
    {
        public string Title { get; set; }
        public List<CustomPropertyInfo> Properties { get; set; }
        public List<DataItem> Data { get; set; }
        public ActionResult AddAction { get; set; }
        public ActionResult BackAction { get; set; }
        public string IsImage { get; set; }
    }
}