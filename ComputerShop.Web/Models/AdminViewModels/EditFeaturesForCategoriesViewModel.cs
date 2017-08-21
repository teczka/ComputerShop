using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AdminViewModels
{
    public class EditFeaturesForCategoriesViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<Feature> FeaturesNotAssignedToCategory { get; set; }
        public IEnumerable<Feature> FeaturesAssignedToCategory { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<int> SelectedFeaturesId { get; set; }
    }
}