using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Roles
{
    public class RoleDataSource : DataSource
    {
        public RoleDataSource() : base(new RoleViewModel()) 
        {

        }

        public List<RoleViewModel> Roles { get; set; }

        public override void PrepareData()
        {
            foreach (var role in this.Roles)
            {
                var row = new DataItem();
                foreach (var prop in this.Properties)
                {
                    try
                    {
                        row.Values.Add(role.GetType().GetProperty(prop.PropertyName).GetValue(role).ToString());
                    }
                    catch
                    {
                        row.Values.Add(string.Empty);
                    }
                }
                row.EditAction = MVC.Account.Roles.Edit(role.Id);
                row.DeleteAction = MVC.Account.Roles.Delete(role.Id);

                this.Data.Add(row);
            }

            this.AddAction = MVC.Account.Roles.Create();
            this.BackAction = MVC.Account.Users.Index();
            this.Title = "Role użytkowników";
        }
    }
}