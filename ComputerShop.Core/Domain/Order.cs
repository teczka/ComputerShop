using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class Order
    {
        [ForeignKey("Basket")]
        public int Id { get; set; }
        public int BasketId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Basket Basket { get; set; }
    }
}
