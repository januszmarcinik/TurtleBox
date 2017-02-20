using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.Domain.Application.DataSource
{
    public abstract class DataSource
    {
        public DataSource(object model)
        {
            this.Properties = new List<CustomPropertyInfo>();
            var allProperties = model.GetType().GetProperties().ToList();

            foreach (var prop in allProperties)
            {
                var dataSourceListAttribute = prop.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(DataSourceListAttribute));
                if (dataSourceListAttribute != null)
                {
                    var displayAttribute = prop.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(DisplayAttribute));
                    if (displayAttribute != null)
                    {
                        this.Properties.Add(new CustomPropertyInfo()
                        {
                            PropertyName = prop.Name,
                            DisplayName = displayAttribute.NamedArguments.First().TypedValue.Value.ToString(),
                            Order = (int)dataSourceListAttribute.NamedArguments.First().TypedValue.Value
                        });
                    }
                }
            }

            if (this.Properties.Count() > 1)
            {
                this.Properties = this.Properties.OrderBy(x => x.Order).ToList();
            }

            this.Data = new List<DataItem>();
        }

        public long ParentId { get; set; }
        public string Title { get; set; }
        public ActionResult AddAction { get; set; }
        public ActionResult BackAction { get; set; }

        public List<CustomPropertyInfo> Properties { get; set; }
        public List<DataItem> Data { get; set; }

        public abstract void PrepareData();
    }
}