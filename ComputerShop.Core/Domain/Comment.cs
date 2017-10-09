using ComputerShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public AssemblyGrade AssemblyGrade { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
