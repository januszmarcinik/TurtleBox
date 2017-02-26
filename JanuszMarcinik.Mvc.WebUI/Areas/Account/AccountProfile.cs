using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Identity.Entities;
using JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Roles;
using JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Users;
using Microsoft.AspNet.Identity.EntityFramework;

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
            CreateMap<IdentityRole, RoleViewModel>();

            CreateMap<ApplicationUser, UserViewModel>()
                .Ignore(p => p.SelectedRoles)
                .Ignore(p => p.AllRoles);
        }
        #endregion
    }
}