using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Identity.Entities
{
    [Table("Roles", Schema = "Identity")]
    public class Role : IdentityRole<int, UserRole>
    {
    }
}