using System;

namespace JanuszMarcinik.Mvc.Domain.Application.DataSource
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DataSourceListAttribute : Attribute
    {
        public int Order { get; set; }
    }
}