using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ComputerShopContext context;

        public UserRepository(ComputerShopContext context)
        {
            this.context = context;
        }
        
        public IEnumerable<User> GetAll()
        {
            return context.Users.AsEnumerable();
        }

        public User Get(int id)
        {
            return context.Users.SingleOrDefault(e => e.Id == id);
        }
        
        public void Insert(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Users.Add(entity);
            context.SaveChanges();
        }
        public void Update(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public void Delete(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Users.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Users.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
