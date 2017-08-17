using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ComputerShopContext context;

        public CategoryRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.AsEnumerable();
        }

        public Category Get(int id)
        {
            return context.Categories.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Categories.Add(entity);
            context.SaveChanges();
        }
        public void Update(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Categories.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Categories.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
