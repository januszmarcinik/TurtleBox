using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Roles
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [DataSourceList(Order = 1)]
        [Display(Name = "Nazwa roli")]
        [StringLength(256, ErrorMessage = "Nazwa roli może zawierać do 256 znaków.")]
        public string Name { get; set; }
    }
}