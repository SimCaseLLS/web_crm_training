using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Models;
using TrainingCentersCRM.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace TrainingCentersCRM.Controllers.Admin
{
    public class UserRolesController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();
        //
        // GET: /Roles?tc=ulstu
        public ActionResult Index(string tc = "")
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var model = new SelectionUsersRolesViewModel();
            var roles = new List<IdentityRole>();

            if (tc.Equals("") || tc.Equals("empty"))
            {
                roles = context.Roles.Where(x => !x.Name.Contains("_")).OrderBy(r => r.Name).ToList();//только общие роли admin и manager
            }
            else
            {
                tc = string.Format("_{0}", tc);
                roles = context.Roles.Where(x => x.Name.Contains(tc)).OrderBy(r => r.Name).ToList();//роли admin_tc, etc.
            }
            
            foreach (var user in context.Users)
            {
                var userViewModel = new SelectionUserEditorViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
                userViewModel.Roles = roles.Select(
                    role => new SelectionRoleEditorViewModel()
                    {
                        Name = role.Name,
                        Selected = userManager.IsInRole(user.Id, role.Name)
                    }).ToList();

                model.Users.Add(userViewModel);
            }
            ViewBag.Roles = roles;
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> SubmitSelected(SelectionUsersRolesViewModel model)
        {
            var account = new AccountController();
            var roles = context.Roles.OrderBy(r => r.Name).ToList();

            foreach (var user in model.Users)
            {
                foreach (var role in user.Roles)
                {
                    if (needRemoveRole(account.UserManager, user, role))
                    {
                        await account.UserManager.RemoveFromRoleAsync(user.Id, role.Name);
                    }
                    else if (needAddRole(account.UserManager, user, role))
                    {
                        await account.UserManager.AddToRoleAsync(user.Id, role.Name);
                    }
                }
            }
            return RedirectToAction("Index");
        }


        private bool needRemoveRole(UserManager<ApplicationUser> userManager, SelectionUserEditorViewModel user, SelectionRoleEditorViewModel role)
        {
            return userManager.IsInRole(user.Id, role.Name) && !role.Selected;
        }
        private bool needAddRole(UserManager<ApplicationUser> userManager, SelectionUserEditorViewModel user, SelectionRoleEditorViewModel role)
        {
            return !userManager.IsInRole(user.Id, role.Name) && role.Selected;
        }
    }
}