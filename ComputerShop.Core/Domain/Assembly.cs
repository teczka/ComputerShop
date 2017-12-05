using ComputerShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class Assembly
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AssemblyRole AssemblyRole { get; set; }
        public bool IsFinished { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
