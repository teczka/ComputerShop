using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AdminViewModels
{
    public class AddNewGroupViewModel
    {
        [Required]
        public string GroupName { get; set; }
    }
}