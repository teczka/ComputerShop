﻿using ComputerShop.Infrastructure.Services;
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

        public ProductsController(ShopService shopService, AdminService adminService)
        {
            this.shopService = shopService;
            this.adminService = adminService;
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
    }
}