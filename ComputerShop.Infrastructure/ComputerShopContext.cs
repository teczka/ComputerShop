using ComputerShop.Core.Domain;
using System.Data.Entity;

namespace ComputerShop.Infrastructure
{
    public class ComputerShopContext : DbContext
    {
        public ComputerShopContext() : base("ComputerShopContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureValue> FeatureValues { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FeatureValueForProduct> FeatureValueForProducts { get; set; }
    }
}
