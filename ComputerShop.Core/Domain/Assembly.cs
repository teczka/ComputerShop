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
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public AssemblyRole AssemblyRole { get; set; }

        public virtual User User { get; set; }
    }
}
