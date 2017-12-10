using ComputerShop.Core.Domain;
using ComputerShop.Infrastructure;
using ComputerShop.Infrastructure.Services;
using ComputerShop.Web.Models.ShopViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace ComputerShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private ShopService shopService;
        private AdminService adminService;

        public ProductsController(ShopService shopService, AdminService adminService, ComputerShopContext context)
        {
            this.shopService = new ShopService(context);
            this.adminService = new AdminService(context);
        }

        // GET: Products
        public ActionResult ProductsList(ProductsListViewModel model)
        {
            model.AllGroups = adminService.GetAllGroups().ToList();
            model.PageInfo = shopService.GetPageInfo(model.GroupId, model.CategoryId, model.CurrentPage);
            model.Products = shopService.GetProducts(model.PageInfo, model.GroupId, model.CategoryId);
            if (WebSecurity.IsAuthenticated)
            {
                model.Basket = shopService.GetOpenBasketForUserId(WebSecurity.CurrentUserId);
            }
            
            return View(model);
        }

        public ActionResult AddProductToBasket(int productId)
        {
            var userId = WebSecurity.CurrentUserId;
            shopService.AddProductToBasket(productId, userId);
            return RedirectToAction(nameof(ProductsList));
        }

        public ActionResult RemoveItemFromBasket(int basketId, int productId)
        {
            shopService.RemoveItemFromBasket(basketId, productId);
            return RedirectToAction(nameof(ProductsList));
        }

        [HttpGet]
        public ActionResult MakeAnOrder(int basketId)
        {
            return View(new MakeOrderViewModel() { Basket = shopService.GetBasketById(basketId), BasketId = basketId, Sum = shopService.SumProductsFromBasket(basketId) });
        }

        [HttpPost]
        public ActionResult MakeAnOrder(MakeOrderViewModel model)
        {
            shopService.CreateOrder(model.BasketId, model.Address);
            return null;
        }
    }
}