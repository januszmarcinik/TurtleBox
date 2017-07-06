using Microsoft.AspNet.Identity.EntityFramework;
using JanuszMarcinik.Mvc.Domain.Data;
using JanuszMarcinik.Mvc.Domain.Identity.Entities;

namespace JanuszMarcinik.Mvc.Domain.Identity.Managers
{
    public class ApplicationRoleStore : RoleStore<Role, int, UserRole>
    {
        public ApplicationRoleStore(ApplicationDbContext context) : base(context)
        {
        }
    }
}