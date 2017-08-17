using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AdminViewModels
{
    public class EditGroupViewModel
    {
        public int Id { get; set; }
        [Required]
        public string GroupName { get; set; }
    }
}