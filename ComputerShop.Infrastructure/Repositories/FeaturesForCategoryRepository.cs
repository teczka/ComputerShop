using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class FeaturesForCategoryRepository : IRepository<FeaturesForCategory>
    {
        private readonly ComputerShopContext context;

        public FeaturesForCategoryRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<FeaturesForCategory> GetAll()
        {
            return context.FeaturesForCategories.AsEnumerable();
        }

        public FeaturesForCategory Get(int id)
        {
            return context.FeaturesForCategories.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(FeaturesForCategory entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.FeaturesForCategories.Add(entity);
            context.SaveChanges();
        }
        public void Update(FeaturesForCategory entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(FeaturesForCategory entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.FeaturesForCategories.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(FeaturesForCategory entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.FeaturesForCategories.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
