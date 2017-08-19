using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int GroupId { get; set; }
        public bool IsAssemblyCategory { get; set; }

        public virtual Group Group { get; set; }
        public virtual IEnumerable<FeaturesForCategory> FeatureForCategory { get; set; }
    }
}
