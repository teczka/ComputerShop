using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class ProducentRepository : IRepository<Producent>
    {
        private readonly ComputerShopContext context;

        public ProducentRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Producent> GetAll()
        {
            return context.Producents.AsEnumerable();
        }

        public Producent Get(int id)
        {
            return context.Producents.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(Producent entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Producents.Add(entity);
            context.SaveChanges();
        }
        public void Update(Producent entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Producent entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Producents.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(Producent entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Producents.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
