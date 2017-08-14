using ComputerShop.Infrastructure.Services;
using ComputerShop.Web.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private AccountService accountService = new AccountService();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel model)
        {
            accountService.RegisterUser(new Core.Domain.User() { Email = model.Email, Name = model.Name, Surname = model.Surname, PhoneNumber = model.PhoneNumber }, model.Password);
            accountService.AssignToRole(model.Email, Core.Enums.ShopRoles.Customer);
            return View("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new UserLoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            accountService.LoginUser(model.Email, model.Password);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            accountService.LogoutUser();
            return RedirectToAction("Index", "Home");
        }
    }
}