using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class BasketRepository : IRepository<Basket>
    {
        private readonly ComputerShopContext context;

        public BasketRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Basket> GetAll()
        {
            return context.Baskets.AsEnumerable();
        }

        public Basket Get(int id)
        {
            return context.Baskets.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(Basket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Baskets.Add(entity);
            context.SaveChanges();
        }
        public void Update(Basket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Basket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Baskets.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(Basket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Baskets.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
