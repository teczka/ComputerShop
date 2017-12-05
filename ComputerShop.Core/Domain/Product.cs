using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ProducentId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<FeatureValueForProduct> FeatureValuesForProduct { get; set; }
        public virtual Producent Producent { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
        public virtual ICollection<Assembly> Assemblies { get; set; }
    }
}
