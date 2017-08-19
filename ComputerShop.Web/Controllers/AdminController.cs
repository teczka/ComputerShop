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
            adminService.AddNewCategory(new Category() { CategoryName = model.CategoryName, GroupId = model.AssignedToGroupId, IsAssemblyCategory = model.IsAssembly });
            return RedirectToAction(nameof(CategoriesPanel));
        }

        [HttpGet]
        public ActionResult EditCategory(int categoryId)
        {
            Category localCategory = adminService.GetCategoryById(categoryId);
            var groups = adminService.GetAllGroups();
            return View(new EditCategoryViewModel() { CategoryName = localCategory.CategoryName, Id = categoryId, AllGroups = groups, IsAssembly = localCategory.IsAssemblyCategory });
        }

        [HttpPost]
        public ActionResult EditCategory(EditCategoryViewModel model)
        {
            adminService.EditCategory(new Category() { CategoryName = model.CategoryName, Id = model.Id, GroupId = model.AssignedToGroupId, IsAssemblyCategory = model.IsAssembly });
            return RedirectToAction(nameof(CategoriesPanel));
        }

        public ActionResult DeleteCategory(int categoryId)
        {
            adminService.DeleteCategory(categoryId);
            return RedirectToAction(nameof(CategoriesPanel));
        }

        //Akcje dla producentów
        public ActionResult ProducentsPanel()
        {
            var model = adminService.GetAllProducents();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddNewProducent()
        {
            return View(new AddNewProducentViewModel());
        }

        public ActionResult AddNewProducent(AddNewProducentViewModel model)
        {
            adminService.AddNewProducent(new Producent() { Name = model.ProducentName });
            return RedirectToAction(nameof(ProducentsPanel));
        }

        [HttpGet]
        public ActionResult EditProducent(int producentId)
        {
            Producent localProducent = adminService.GetProducentById(producentId);
            return View(new EditProducentViewModel() { ProducentName = localProducent.Name, Id = producentId });
        }

        [HttpPost]
        public ActionResult EditProducent(EditProducentViewModel model)
        {
            adminService.EditProducent(new Producent() { Id = model.Id, Name = model.ProducentName });
            return RedirectToAction(nameof(ProducentsPanel));
        }

        public ActionResult DeleteProducent(int producentId)
        {
            adminService.DeleteProducent(producentId);
            return RedirectToAction(nameof(ProducentsPanel));
        }

        //Akcje dla cech
        public ActionResult FeaturesPanel()
        {
            var model = adminService.GetAllFeatures();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddNewFeature()
        {
            return View(new AddNewFeatureViewModel());
        }

        [HttpPost]
        public ActionResult AddNewFeature(AddNewFeatureViewModel model)
        {
            adminService.AddNewFeature(new Feature() { Name = model.FeatureName });
            return RedirectToAction(nameof(FeaturesPanel));
        }

        [HttpGet]
        public ActionResult EditFeature(int featureId)
        {
            return View(new EditFeatureViewModel()
            {
                FeatureId = featureId,
                FeatureName = adminService.GetFeatureById(featureId).Name,
                FeatureValues = adminService.GetFeatureValuesForFeatureId(featureId)
            });
        }

        [HttpPost]
        public ActionResult EditFeature(EditFeatureViewModel model)
        {
            adminService.EditFeature(new Feature() { Name = model.FeatureName, Id = model.FeatureId });
            return RedirectToAction(nameof(FeaturesPanel));
        }

        public ActionResult DeleteFeature(int featureId)
        {
            adminService.DeleteFeature(featureId);
            return RedirectToAction(nameof(FeaturesPanel));
        }

        public ActionResult AddNewFeatureValue(EditFeatureViewModel model)
        {
            adminService.AddNewFeatureValue(new FeatureValue() { Name = model.FeatureValueName, FeatureId = model.FeatureId });
            return RedirectToAction("EditFeature", new { featureId = model.FeatureId });
        }

        [HttpGet]
        public ActionResult EditFeatureValue(int featureValueId)
        {
            var localFeatureValue = adminService.GetFeatureValueById(featureValueId);
            return View(new EditFeatureValueViewModel { FeatureValueName = localFeatureValue.Name, Id = localFeatureValue.Id });
        }

        [HttpPost]
        public ActionResult EditFeatureValue(EditFeatureValueViewModel model)
        {
            var featureId = adminService.GetFeatureValueById(model.Id).FeatureId;
            var featureValue = adminService.GetFeatureValueById(model.Id);
            featureValue.Name = model.FeatureValueName;
            adminService.EditFeatureValue(featureValue);
            return RedirectToAction("EditFeature", new { featureId = featureId });
        }

        public ActionResult DeleteFeatureValue(int featureValueId, int featureId)
        {
            adminService.DeleteFeatureValue(featureValueId);
            return RedirectToAction("EditFeature", new { featureId = featureId });
        }
    }
}