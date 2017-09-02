using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ComputerShopContext context;

        public OrderRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders.AsEnumerable();
        }

        public Order Get(int id)
        {
            return context.Orders.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Orders.Add(entity);
            context.SaveChanges();
        }
        public void Update(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Orders.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Orders.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
