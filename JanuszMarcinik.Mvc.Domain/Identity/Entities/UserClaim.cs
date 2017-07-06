using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Identity.Entities
{
    [Table("UserClaims", Schema = "Identity")]
    public class UserClaim : IdentityUserClaim<int>
    {
    }
}