using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AdminViewModels
{
    public class AddNewCategoryViewModel
    {
        [Required]
        public string CategoryName { get; set; }
        public int AssignedToGroupId { get; set; }
        public bool IsAssembly { get; set; }
        public bool IsRequired { get; set; }
        public IEnumerable<Group> AllGroups { get; set; }
    }
}