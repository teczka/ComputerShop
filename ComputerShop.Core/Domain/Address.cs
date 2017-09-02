using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class Address
    {
        [ForeignKey("Order")]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Line { get; set; }

        public virtual Order Order { get; set; }
    }
}
