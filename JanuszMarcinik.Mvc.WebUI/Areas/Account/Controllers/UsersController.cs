using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Identity.Context;
using JanuszMarcinik.Mvc.Domain.Identity.Entities;
using JanuszMarcinik.Mvc.Domain.Identity.Managers;
using JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Roles;
using JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Controllers
{
    [Authorize(Roles = "Administrator")]
    public partial class UsersController : Controller
    {
        #region UsersController()
        private ApplicationUserManager _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UsersController(ApplicationIdentityDbContext context)
        {
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public UsersController(ApplicationUserManager userManager, ApplicationIdentityDbContext context)
        {
            UserManager = userManager;
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }
        #endregion

        #region Index()
        public virtual ActionResult Index()
        {
            return View();
        }
        #endregion

        #region List()
        public virtual ActionResult List()
        {
            var users = UserManager.Users;
            var model = new UserDataSource();
            model.Users = Mapper.Map<List<UserViewModel>>(users);
            model.PrepareData();

            return View(MVC.Admin.Shared.Views.Grid, model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(string id)
        {
            var user = UserManager.Users.FirstOrDefault(x => x.Id == id);
            var model = Mapper.Map<UserViewModel>(user);

            foreach (var role in _roleManager.Roles)
            {
                model.AllRoles.Add(new SelectListItem()
                {
                    Value = role.Id,
                    Text = role.Name,
                    Selected = user.Roles.Any(x => x.RoleId == role.Id)
                });
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Users.FirstOrDefault(x => x.Id == model.Id);
                user.UserName = model.UserName;
                user.Email = model.Email;

                user.Roles.Clear();
                foreach (var selectedRole in model.SelectedRoles)
                {
                    user.Roles.Add(new IdentityUserRole()
                    {
                        RoleId = selectedRole,
                        UserId = user.Id
                    });
                }

                UserManager.Update(user);

                return RedirectToAction(MVC.Account.Users.List());
            }

            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(string id)
        {
            var user = UserManager.Users.FirstOrDefault(x => x.Id == id);
            var model = Mapper.Map<UserViewModel>(user);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(UserViewModel model)
        {
            var user = UserManager.Users.FirstOrDefault(x => x.Id == model.Id);
            UserManager.DeleteAsync(user);

            return RedirectToAction(MVC.Account.Users.List());
        }
        #endregion
    }
}