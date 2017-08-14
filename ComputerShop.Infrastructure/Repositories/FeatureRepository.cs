using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class FeatureRepository : IRepository<Feature>
    {
        private readonly ComputerShopContext context;

        public FeatureRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Feature> GetAll()
        {
            return context.Features.AsEnumerable();
        }

        public Feature Get(int id)
        {
            return context.Features.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(Feature entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Features.Add(entity);
            context.SaveChanges();
        }
        public void Update(Feature entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public void Delete(Feature entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Features.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(Feature entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Features.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
