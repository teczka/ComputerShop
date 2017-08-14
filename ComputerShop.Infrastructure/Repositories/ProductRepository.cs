using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ComputerShopContext context;

        public ProductRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.AsEnumerable();
        }

        public Product Get(int id)
        {
            return context.Products.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Products.Add(entity);
            context.SaveChanges();
        }
        public void Update(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public void Delete(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Products.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Products.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
