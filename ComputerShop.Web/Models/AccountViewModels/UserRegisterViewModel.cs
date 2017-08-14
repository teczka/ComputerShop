using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AccountViewModels
{
    public class UserRegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        [Required]
        [StringLength(20)]
        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Surname { get; set; }
        [Required]
        [RegularExpression("([0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9])", ErrorMessage = "Podałeś nieprawidłowy numer telefonu")]
        public int PhoneNumber { get; set; }
    }
}