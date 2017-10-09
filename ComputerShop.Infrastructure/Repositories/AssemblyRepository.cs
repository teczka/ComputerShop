using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class AssemblyRepository : IRepository<Assembly>
    {
        private readonly ComputerShopContext context;

        public AssemblyRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Assembly> GetAll()
        {
            return context.Assemblies.AsEnumerable();
        }

        public Assembly Get(int id)
        {
            return context.Assemblies.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(Assembly entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Assemblies.Add(entity);
            context.SaveChanges();
        }
        public void Update(Assembly entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Assembly entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Assemblies.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(Assembly entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Assemblies.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
