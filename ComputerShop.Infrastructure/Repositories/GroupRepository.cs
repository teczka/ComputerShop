using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly ComputerShopContext context;

        public GroupRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Group> GetAll()
        {
            return context.Groups.AsEnumerable();
        }

        public Group Get(int id)
        {
            return context.Groups.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(Group entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Groups.Add(entity);
            context.SaveChanges();
        }
        public void Update(Group entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Group entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Groups.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(Group entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Groups.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
