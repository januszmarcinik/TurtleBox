using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Identity.Entities;
using JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Roles;
using JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Users;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account
{
    public class AccountProfile : Profile
    {
        #region ProfileName
        public override string ProfileName
        {
            get { return this.GetType().FullName; }
        }
        #endregion

        #region AccountProfile()
        public AccountProfile()
        {
            CreateMap<Role, RoleViewModel>();

            CreateMap<User, UserViewModel>()
                .Ignore(p => p.SelectedRoles)
                .Ignore(p => p.AllRoles);
        }
        #endregion
    }
}