using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class FeatureValueForProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FeatureValueId { get; set; }

        public virtual Product Product { get; set; }
        public virtual FeatureValue FeatureValue { get; set; }
    }
}
