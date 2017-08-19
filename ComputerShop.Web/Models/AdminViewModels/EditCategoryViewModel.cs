using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AdminViewModels
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public int AssignedToGroupId { get; set; }
        public IEnumerable<Group> AllGroups { get; set; }
    }
}