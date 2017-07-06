using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JanuszMarcinik.Mvc.Domain.Identity.Entities
{
    [Table("UserRoles", Schema = "Identity")]
    public class UserRole : IdentityUserRole<int>
    {
        [Key]
        public int Id { get; set; }
    }

    internal class ApplicationUserRoleEFConfig : EntityTypeConfiguration<UserRole>
    {
        public ApplicationUserRoleEFConfig()
        {
        }
    }
}