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
        public bool IsAssemblyFeature { get; set; }

        public virtual ICollection<FeatureValue> FeatureValues { get; set; }
        public virtual ICollection<FeaturesForCategory> FeaturesForCategory { get; set; }
    }
}
