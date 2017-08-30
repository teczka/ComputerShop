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
        public DbSet<Producent> Producents { get; set; }
        public DbSet<FeaturesForCategory> FeaturesForCategories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
    }
}
