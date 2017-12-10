using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Enums
{
    public enum AssemblyGrade
    {
        [Display(Name="Straszny")]
        Terrible = 1,
        [Display(Name = "Słaby")]
        Poor = 2,
        [Display(Name = "Średni")]
        Medium = 3,
        [Display(Name = "Dobry")]
        Good = 4,
        [Display(Name = "Bardzo dobry")]
        VeryGood = 5
    }
}
