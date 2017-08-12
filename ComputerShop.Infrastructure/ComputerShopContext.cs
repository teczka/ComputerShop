using ComputerShop.Core.Domain;
using System.Data.Entity;

namespace ComputerShop.Infrastructure
{
    public class ComputerShopContext : DbContext
    {
        public ComputerShopContext() : base("ComputerShopContext") { }

        public DbSet<User> Users { get; set; }
    }
}
