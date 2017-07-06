namespace JanuszMarcinik.Mvc.Domain.Application.DataSource
{
    public class CustomPropertyInfo
    {
        public bool PrimaryKeyProperty { get; set; } = false;
        public bool ImagePathProperty { get; set; } = false;

        public string PropertyName { get; set; }
        public string DisplayName { get; set; }
        public int Order { get; set; }
    }
}