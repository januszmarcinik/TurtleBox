using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Roles
{
    public class RoleDataSource : DataSource<RoleViewModel>
    {
        public RoleDataSource() : base(new RoleViewModel()) { }

        public List<RoleViewModel> Roles { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.Roles);

            foreach (var row in this.Data)
            {
                row.EditAction = MVC.Account.Roles.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Account.Roles.Delete(row.PrimaryKeyId);
            }

            this.AddAction = MVC.Account.Roles.Create();
            this.BackAction = MVC.Account.Users.Index();
            this.Title = "Role użytkowników";
        }
    }
}