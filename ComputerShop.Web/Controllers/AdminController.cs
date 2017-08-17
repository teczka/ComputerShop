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

        //Akcje dla Grup
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

        [HttpPost]
        public ActionResult AddNewGroup(AddNewGroupViewModel model)
        {
            adminService.AddNewGroup(new Group() { GroupName = model.GroupName });
            return RedirectToAction(nameof(GroupsPanel));
        }

        [HttpGet]
        public ActionResult EditGroup(int groupId)
        {
            Group localGroup = adminService.GetGroupById(groupId);
            return View(new EditGroupViewModel() { GroupName = localGroup.GroupName, Id = groupId });
        }

        [HttpPost]
        public ActionResult EditGroup(EditGroupViewModel model)
        {
            adminService.EditGroup(new Group() { GroupName = model.GroupName, Id = model.Id });
            return RedirectToAction(nameof(GroupsPanel));
        }

        public ActionResult DeleteGroup(int groupId)
        {
            adminService.DeleteGroup(groupId);
            return RedirectToAction(nameof(GroupsPanel));
        }

        //Akcje dla Kategorii
        public ActionResult CategoriesPanel()
        {
            var model = adminService.GetAllCategories();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddNewCategory()
        {
            var groups = adminService.GetAllGroups();
            return View(new AddNewCategoryViewModel() { AllGroups = groups });
        }

        [HttpPost]
        public ActionResult AddNewCategory(AddNewCategoryViewModel model)
        {
            adminService.AddNewCategory(new Category() { CategoryName = model.CategoryName, GroupId = model.AssignedToGroupId });
            return RedirectToAction(nameof(CategoriesPanel));
        }
    }
}