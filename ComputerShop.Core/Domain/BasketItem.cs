using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AmountOfProducts { get; set; }

        public virtual Product Product { get; set; }
        public virtual Basket Basket { get; set; }
    }
}
