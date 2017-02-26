using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Users
{
    public class UserDataSource : DataSource
    {
        public UserDataSource() : base(new UserViewModel()) 
        {

        }

        public List<UserViewModel> Users { get; set; }

        public override void PrepareData()
        {
            foreach (var user in this.Users)
            {
                var row = new DataItem();
                foreach (var prop in this.Properties)
                {
                    try
                    {
                        row.Values.Add(user.GetType().GetProperty(prop.PropertyName).GetValue(user).ToString());
                    }
                    catch
                    {
                        row.Values.Add(string.Empty);
                    }
                }
                row.EditAction = MVC.Account.Users.Edit(user.Id);
                row.DeleteAction = MVC.Account.Users.Delete(user.Id);

                this.Data.Add(row);
            }

            this.AddAction = MVC.Account.Account.Register();
            this.BackAction = MVC.Account.Users.Index();
            this.Title = "Użytkownicy";
        }
    }
}