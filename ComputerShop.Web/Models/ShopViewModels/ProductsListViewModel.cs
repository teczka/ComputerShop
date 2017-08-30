using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.ShopViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Group> AllGroups { get; set; }
        public PageInfo PageInfo { get; set; }
        public int GroupId { get; set; }
        public int CategoryId { get; set; }
        public int CurrentPage { get; set; }
        public Basket Basket { get; set; }
    }
}