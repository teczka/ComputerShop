using ComputerShop.Core.Domain;
using ComputerShop.Infrastructure.Services;
using ComputerShop.Web.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerShop.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private AdminService adminService;

        public AdminController(AdminService adminService)
        {
            this.adminService = adminService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GroupsPanel()
        {
            var model = adminService.GetAllGroups();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddNewGroup()
        {
            return View(new AddNewGroupViewModel());
        }

        public ActionResult AddNewGroup(AddNewGroupViewModel model)
        {
            adminService.AddNewGroup(new Group() { GroupName = model.GroupName });
            return RedirectToAction(nameof(GroupsPanel));
        }

        public ActionResult EditGroup()
        {
            return null;
        }
    }
}