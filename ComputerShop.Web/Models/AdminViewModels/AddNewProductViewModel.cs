using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AdminViewModels
{
    public class AddNewProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProducentId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> AllCategories { get; set; }
        public IEnumerable<Producent> AllProducents { get; set; }
    }
}