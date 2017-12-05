using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AssemblyViewModels
{
    public class CreateNewAssemblyViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Assembly CurrentAssembly { get; set; }
    }
}