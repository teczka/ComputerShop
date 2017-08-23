using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AdminViewModels
{
    public class EditFeaturesForProductViewModel
    {
        public int ProductId { get; set; }
        public IEnumerable<Feature> Features { get; set; }
        public IEnumerable<int> SelectedFeatureValueIds { get; set; }
    }
}