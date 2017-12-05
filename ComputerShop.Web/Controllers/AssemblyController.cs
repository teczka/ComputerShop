using ComputerShop.Infrastructure.Services;
using ComputerShop.Web.Models.AssemblyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
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
    }
}