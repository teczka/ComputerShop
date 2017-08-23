using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
