using ComputerShop.Core.Domain;
using ComputerShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Repositories
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly ComputerShopContext context;

        public AddressRepository(ComputerShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Address> GetAll()
        {
            return context.Addresses.AsEnumerable();
        }

        public Address Get(int id)
        {
            return context.Addresses.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(Address entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Addresses.Add(entity);
            context.SaveChanges();
        }
        public void Update(Address entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Address entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Addresses.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(Address entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Addresses.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
