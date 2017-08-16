using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class FeatureValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FeatureId { get; set; }

        public virtual Feature Feature { get; set; }
        public virtual IEnumerable<FeatureValueForProduct> FeatureValuesForProduct { get; set; }
    }
}
