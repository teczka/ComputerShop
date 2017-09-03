using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AdminViewModels
{
    public class EditFeatureViewModel
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public string FeatureValueName { get; set; }
        public bool IsAssembly { get; set; }
        public IEnumerable<FeatureValue> FeatureValues { get; set; }
    }
}