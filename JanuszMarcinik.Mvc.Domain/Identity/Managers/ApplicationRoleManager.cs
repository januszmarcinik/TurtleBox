using JanuszMarcinik.Mvc.Domain.Identity.Entities;
using Microsoft.AspNet.Identity;

namespace JanuszMarcinik.Mvc.Domain.Identity.Managers
{
    public class ApplicationRoleManager : RoleManager<Role, int>
    {
        public ApplicationRoleManager(IRoleStore<Role, int> store) : base(store)
        {

        }
    }
}