using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Users
{
    public class UserDataSource : DataSource<UserViewModel>
    {
        public UserDataSource() : base(new UserViewModel()) { }

        public List<UserViewModel> Users { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.Users);

            foreach (var row in this.Data)
            {
                row.EditAction = MVC.Account.Users.Edit(row.PrimaryKeyStringId);
                row.DeleteAction = MVC.Account.Users.Delete(row.PrimaryKeyStringId);
            }

            this.AddAction = MVC.Account.Account.Register();
            this.BackAction = MVC.Account.Users.Index();
            this.Title = "Użytkownicy";
        }
    }
}