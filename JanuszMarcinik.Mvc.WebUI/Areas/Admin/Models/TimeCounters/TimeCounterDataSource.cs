using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.TimeCounters
{
    public class TimeCounterDataSource : DataSource<TimeCounterViewModel>
    {
        public TimeCounterDataSource() : base(new TimeCounterViewModel()) { }

        public List<TimeCounterViewModel> TimeCounters { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.TimeCounters);

            foreach (var row in this.Data)
            {
                row.EditAction = MVC.Admin.TimeCounters.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Admin.TimeCounters.Delete(row.PrimaryKeyId);
            }

            this.AddAction = MVC.Admin.TimeCounters.Create();
            this.BackAction = MVC.Admin.Configuration.Index();
            this.Title = "Odliczania";
        }
    }
}