using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class FeatureValueForProductRepository : IRepository<FeatureValueForProduct>
    {
        private readonly ComputerShopContext context;

        public FeatureValueForProductRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<FeatureValueForProduct> GetAll()
        {
            return context.FeatureValueForProducts.AsEnumerable();
        }

        public FeatureValueForProduct Get(int id)
        {
            return context.FeatureValueForProducts.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(FeatureValueForProduct entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.FeatureValueForProducts.Add(entity);
            context.SaveChanges();
        }
        public void Update(FeatureValueForProduct entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(FeatureValueForProduct entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.FeatureValueForProducts.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(FeatureValueForProduct entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.FeatureValueForProducts.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
