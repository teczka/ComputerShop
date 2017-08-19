using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class FeaturesForCategory
    {
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public int CategoryId { get; set; }

        public virtual Feature Feature { get; set; }
        public virtual Category Category { get; set; }
    }
}
