using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.ShopViewModels
{
    public class MakeOrderViewModel
    {
        public Basket Basket { get; set; }
        public Address Address { get; set; }
        public int BasketId { get; set; }
    }
}