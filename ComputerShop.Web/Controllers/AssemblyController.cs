using ComputerShop.Infrastructure.Services;
using ComputerShop.Web.Models.AssemblyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace ComputerShop.Web.Controllers
{
    [Authorize]
    public class AssemblyController : Controller
    {
        private AssemblyService assemblyService;

        public AssemblyController(AssemblyService assemblyService)
        {
            this.assemblyService = assemblyService;
        }

        // GET: Assembly
        public ActionResult AssemblyMenu()
        {
            var model = new AssembliesViewModel()
            {
                Assemblies = assemblyService.GetListOfFinishedAssemblies()
            };
            return View(model);
        }

        public ActionResult CreateNewAssembly(int userId)
        {
            var model = new CreateNewAssemblyViewModel()
            {
                Categories = assemblyService.GetAssemblyCategories(),
                CurrentAssembly = assemblyService.GetCurrentAssembly(userId)
            };
            return View(model);
        }

        public ActionResult MatchProductToAssembly(int userId, int categoryId)
        {
            var model = new SelectProductToAssemblyViewModel()
            {
                Products = assemblyService.GetMatchingProductsForCategory(userId, categoryId),
                UserId = userId,
                CurrentAssemblyId = assemblyService.GetCurrentAssembly(userId).Id
            };
            return View(model);
        }

        public ActionResult MatchProductToAssemblyWithModel(SelectProductToAssemblyViewModel model)
        {
            assemblyService.AddProductToAssembly(model.SelectedProductId, model.CurrentAssemblyId);
            return RedirectToAction(nameof(CreateNewAssembly), new { model.UserId });
        }

        public ActionResult FinishCurrentAssembly(int userId)
        {
            assemblyService.FinishCurrentAssembly(userId);
            return RedirectToAction(nameof(AssemblyMenu));
        }

        public ActionResult SetAssemblyRole(string AssemblyRole, string assemblyId)
        {
            assemblyService.SetAssemblyRole(AssemblyRole, assemblyId);
            return RedirectToAction(nameof(AssemblyMenu));
        }

        [HttpGet]
        public ActionResult AddComment(int assemblyId, int userId)
        {
            var model = new AddCommentViewModel()
            {
                AssemblyId = assemblyId,
                UserId = userId,
                CommentedAssembly = assemblyService.GetAsseblyById(assemblyId)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddComment(AddCommentViewModel model)
        {
            assemblyService.AddComment(model.AssemblyId, model.CurrentUserId, model.Text, model.Grade);
            return RedirectToAction(nameof(AssemblyMenu));
        }
    }
}