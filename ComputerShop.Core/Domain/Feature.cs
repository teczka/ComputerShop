using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<FeatureValue> FeatureValues { get; set; }
        public virtual IEnumerable<FeaturesForCategory> FeaturesForCategory { get; set; }
    }
}
