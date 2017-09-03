using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }    
        public bool IsClosed { get; set; }

        public virtual ICollection<BasketItem> BasketItems { get; set; }
        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
    }
}
