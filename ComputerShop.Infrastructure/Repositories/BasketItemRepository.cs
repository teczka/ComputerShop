using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class BasketItemRepository : IRepository<BasketItem>
    {
        private readonly ComputerShopContext context;

        public BasketItemRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<BasketItem> GetAll()
        {
            return context.BasketItems.AsEnumerable();
        }

        public BasketItem Get(int id)
        {
            return context.BasketItems.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(BasketItem entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.BasketItems.Add(entity);
            context.SaveChanges();
        }
        public void Update(BasketItem entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(BasketItem entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.BasketItems.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(BasketItem entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.BasketItems.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
