using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AssemblyViewModels
{
    public class SelectProductToAssemblyViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int SelectedProductId { get; set; }
        public int CurrentAssemblyId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}