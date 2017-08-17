using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class FeatureValueRepository : IRepository<FeatureValue>
    {
        private readonly ComputerShopContext context;

        public FeatureValueRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<FeatureValue> GetAll()
        {
            return context.FeatureValues.AsEnumerable();
        }

        public FeatureValue Get(int id)
        {
            return context.FeatureValues.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(FeatureValue entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.FeatureValues.Add(entity);
            context.SaveChanges();
        }
        public void Update(FeatureValue entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(FeatureValue entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.FeatureValues.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(FeatureValue entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.FeatureValues.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
