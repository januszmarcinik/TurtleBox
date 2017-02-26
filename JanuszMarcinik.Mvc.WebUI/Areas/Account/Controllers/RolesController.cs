using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Identity.Context;
using JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Roles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Controllers
{
    public partial class RolesController : Controller
    {
        #region RolesController()
        private RoleManager<IdentityRole> _roleManager;

        public RolesController(ApplicationIdentityDbContext context)
        {
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }
        #endregion

        #region List()
        public virtual ActionResult List()
        {
            var roles = _roleManager.Roles;
            var model = new RoleDataSource();
            model.Roles = Mapper.Map<List<RoleViewModel>>(roles);
            model.PrepareData();

            return View(MVC.Admin.Shared.Views.Grid, model);
        }
        #endregion

        #region Create()
        public virtual ActionResult Create()
        {
            var model = new RoleViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                _roleManager.Create(new IdentityRole(model.Name));
                return RedirectToAction(MVC.Account.Roles.List());
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var model = Mapper.Map<RoleViewModel>(role);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);
                role.Name = model.Name;
                _roleManager.Update(role);

                return RedirectToAction(MVC.Account.Roles.List());
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var model = Mapper.Map<RoleViewModel>(role);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(RoleViewModel model)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);
            _roleManager.Delete(role);

            return RedirectToAction(MVC.Account.Roles.List());
        }
        #endregion
    }
}