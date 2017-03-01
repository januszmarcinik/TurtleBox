using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.Domain.Application.DataSource
{
    public abstract class DataSource<TModel> where TModel : class
    {
        public DataSource(TModel model)
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
                else if (prop.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(PrimaryKeyAttribute)) != null)
                {
                    this.Properties.Add(new CustomPropertyInfo()
                    {
                        PropertyName = prop.Name,
                        PrimaryKeyProperty = true
                    });
                }
                else if (prop.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(PrimaryKeyStringAttribute)) != null)
                {
                    this.Properties.Add(new CustomPropertyInfo()
                    {
                        PropertyName = prop.Name,
                        PrimaryKeyStringProperty = true
                    });
                }
                else if (prop.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(ImagePathAttribute)) != null)
                {
                    this.Properties.Add(new CustomPropertyInfo()
                    {
                        PropertyName = prop.Name,
                        ImagePathProperty = true
                    });
                }
            }

            if (this.Properties.Count() > 1)
            {
                this.Properties = this.Properties.OrderBy(x => x.Order).ToList();
            }
        }

        public string IsImage = "ImageValue";

        public string Title { get; set; }
        public ActionResult AddAction { get; set; }
        public ActionResult BackAction { get; set; }

        public List<CustomPropertyInfo> Properties { get; set; }
        public List<DataItem> Data { get; set; }

        protected virtual void PrepareData(List<TModel> data)
        {
            this.Data = new List<DataItem>();

            foreach (var item in data)
            {
                var row = new DataItem();
                foreach (var prop in this.Properties)
                {
                    if (prop.PrimaryKeyProperty)
                    {
                        row.PrimaryKeyId = (long)item.GetType().GetProperty(prop.PropertyName).GetValue(item);
                    }
                    else if (prop.PrimaryKeyStringProperty)
                    {
                        row.PrimaryKeyStringId = item.GetType().GetProperty(prop.PropertyName).GetValue(item).ToString();
                    }
                    else if (prop.ImagePathProperty)
                    {
                        row.ImagePath = item.GetType().GetProperty(prop.PropertyName).GetValue(item).ToString();
                    }
                    else if (item.GetType().GetProperty(prop.PropertyName).PropertyType == typeof(HttpPostedFileBase))
                    {
                        row.Values.Add(this.IsImage);
                    }
                    else if (item.GetType().GetProperty(prop.PropertyName).GetValue(item).GetType().BaseType == typeof(Enum))
                    {
                        var enumValue = (Enum)item.GetType().GetProperty(prop.PropertyName).GetValue(item);
                        row.Values.Add(GetEnumDescription(enumValue));
                    }
                    else
                    {
                        try
                        {
                            row.Values.Add(item.GetType().GetProperty(prop.PropertyName).GetValue(item).ToString());
                        }
                        catch
                        {
                            row.Values.Add(string.Empty);
                        }
                    }
                }

                this.Data.Add(row);
            }
        }

        public abstract void SetActions();

        private string GetEnumDescription(Enum e)
        {
            DescriptionAttribute attribute = e.GetType()
                .GetField(e.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;

            return attribute == null ? e.ToString() : attribute.Description;
        }

        public GridModel GetGridModel()
        {
            return new GridModel()
            {
                AddAction = this.AddAction,
                BackAction = this.BackAction,
                Data = this.Data,
                Properties = this.Properties,
                IsImage = this.IsImage,
                Title = this.Title
            };
        }
    }
}