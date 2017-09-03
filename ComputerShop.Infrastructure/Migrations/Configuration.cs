namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebMatrix.WebData;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<ComputerShop.Infrastructure.ComputerShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ComputerShop.Infrastructure.ComputerShopContext context)
        {
            //Initialize simple membership
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("ComputerShopContext", "Users", "Id", "Email", true);
            }
            //Add roles
            var rolesProvider = System.Web.Security.Roles.Provider;
            if (!rolesProvider.RoleExists("Admin"))
            {
                rolesProvider.CreateRole("Admin");
            }
            if (!rolesProvider.RoleExists("Customer"))
            {
                rolesProvider.CreateRole("Customer");
            }
            if (!rolesProvider.RoleExists("Seller"))
            {
                rolesProvider.CreateRole("Seller");
            }
            //Add admin account
            if (!WebSecurity.UserExists("admin@admin.pl"))
            {
                WebSecurity.CreateUserAndAccount("admin@admin.pl", "haslo1", new { Name = "Admin", Surname = "Systemu", PhoneNumber = "123456789" });
                rolesProvider.AddUsersToRoles(new[] { "admin@admin.pl" }, new[] { "Admin"});
            }

            if (!context.Groups.Any())
            {
                context.Groups.Add(new Core.Domain.Group() { GroupName = "Laptopy", Id = 1 });
                context.Groups.Add(new Core.Domain.Group() { GroupName = "Telefony", Id = 2 });
                context.Groups.Add(new Core.Domain.Group() { GroupName = "Podzespo³y komputerowe", Id = 3 });
            }

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Core.Domain.Category() { Id = 1, CategoryName = "Laptopy 15'6", GroupId = 1, IsAssemblyCategory = false, IsRequiredToAssembly = false });
                context.Categories.Add(new Core.Domain.Category() { Id = 2, CategoryName = "Laptopy 17'3", GroupId = 1, IsAssemblyCategory = false, IsRequiredToAssembly = false });
                context.Categories.Add(new Core.Domain.Category() { Id = 3, CategoryName = "Laptopy pozosta³e", GroupId = 1, IsAssemblyCategory = false, IsRequiredToAssembly = false });
                context.Categories.Add(new Core.Domain.Category() { Id = 4, CategoryName = "Smartfony", GroupId = 2, IsAssemblyCategory = false, IsRequiredToAssembly = false });
                context.Categories.Add(new Core.Domain.Category() { Id = 5, CategoryName = "Telefony tradycyjne", GroupId = 2, IsAssemblyCategory = false, IsRequiredToAssembly = false });
                context.Categories.Add(new Core.Domain.Category() { Id = 6, CategoryName = "Procesory", GroupId = 3, IsAssemblyCategory = true, IsRequiredToAssembly = true });
                context.Categories.Add(new Core.Domain.Category() { Id = 7, CategoryName = "Karty graficzne", GroupId = 3, IsAssemblyCategory = true, IsRequiredToAssembly = false });
                context.Categories.Add(new Core.Domain.Category() { Id = 8, CategoryName = "P³yty g³ówne", GroupId = 3, IsAssemblyCategory = true, IsRequiredToAssembly = true });
                context.Categories.Add(new Core.Domain.Category() { Id = 9, CategoryName = "Pamiêci RAM", GroupId = 3, IsAssemblyCategory = true, IsRequiredToAssembly = true });
                context.Categories.Add(new Core.Domain.Category() { Id = 10, CategoryName = "Zasilacze", GroupId = 3, IsAssemblyCategory = true, IsRequiredToAssembly = true });
                context.Categories.Add(new Core.Domain.Category() { Id = 11, CategoryName = "Obudowy", GroupId = 3, IsAssemblyCategory = true, IsRequiredToAssembly = true });
                context.Categories.Add(new Core.Domain.Category() { Id = 12, CategoryName = "Dyski SSD", GroupId = 3, IsAssemblyCategory = true, IsRequiredToAssembly = false });
                context.Categories.Add(new Core.Domain.Category() { Id = 13, CategoryName = "Dyski HDD", GroupId = 3, IsAssemblyCategory = true, IsRequiredToAssembly = false });
                context.Categories.Add(new Core.Domain.Category() { Id = 14, CategoryName = "Systemy operacyjne", GroupId = 3, IsAssemblyCategory = true, IsRequiredToAssembly = false });
                context.Categories.Add(new Core.Domain.Category() { Id = 15, CategoryName = "Ch³odzenie procesora", GroupId = 3, IsAssemblyCategory = true, IsRequiredToAssembly = false });
            }

            if (!context.Producents.Any())
            {
                context.Producents.Add(new Core.Domain.Producent() { Id = 1, Name = "Lenovo" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 2, Name = "Dell" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 3, Name = "MSI" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 4, Name = "ASUS" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 5, Name = "Acer" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 6, Name = "Apple" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 7, Name = "Microsoft" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 8, Name = "Huawei" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 9, Name = "Samsung" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 10, Name = "Nokia" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 11, Name = "Motorola" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 12, Name = "Sony" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 13, Name = "LG" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 14, Name = "WD" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 15, Name = "Seagate" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 16, Name = "ADATA" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 17, Name = "Kingston" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 18, Name = "Gigabyte" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 19, Name = "ASRock" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 20, Name = "HyperX" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 21, Name = "Corsair" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 22, Name = "Crucial" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 23, Name = "GOODRAM" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 24, Name = "SilentiumPC" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 25, Name = "be quiet!" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 26, Name = "Fractal Design" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 27, Name = "Chieftec" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 28, Name = "Intel" });
                context.Producents.Add(new Core.Domain.Producent() { Id = 29, Name = "AMD" });
            }

            if (!context.Features.Any())
            {
                context.Features.Add(new Core.Domain.Feature() { Id = 1, Name = "Rodzina procesorów", IsAssemblyFeature = false });
                context.Features.Add(new Core.Domain.Feature() { Id = 2, Name = "Socket", IsAssemblyFeature = true });
                context.Features.Add(new Core.Domain.Feature() { Id = 3, Name = "Rodzaj pamiêci", IsAssemblyFeature = true });
                context.Features.Add(new Core.Domain.Feature() { Id = 4, Name = "Iloœæ banków pamiêci", IsAssemblyFeature = false });
                context.Features.Add(new Core.Domain.Feature() { Id = 5, Name = "Z³¹cze karty graficznej", IsAssemblyFeature = true });
                context.Features.Add(new Core.Domain.Feature() { Id = 6, Name = "Z³¹cze dysku twardego", IsAssemblyFeature = true });
                context.Features.Add(new Core.Domain.Feature() { Id = 7, Name = "Format p³yty g³ównej", IsAssemblyFeature = true });
                context.Features.Add(new Core.Domain.Feature() { Id = 8, Name = "Pojemnoœæ dysku", IsAssemblyFeature = false });
                context.Features.Add(new Core.Domain.Feature() { Id = 9, Name = "Pamiêæ karty graficznej", IsAssemblyFeature = false });
                context.Features.Add(new Core.Domain.Feature() { Id = 10, Name = "Typ obudowy", IsAssemblyFeature = false });
                context.Features.Add(new Core.Domain.Feature() { Id = 11, Name = "Standard zasilacza", IsAssemblyFeature = true });
                context.Features.Add(new Core.Domain.Feature() { Id = 12, Name = "Moc zasilacza", IsAssemblyFeature = false });
                context.Features.Add(new Core.Domain.Feature() { Id = 13, Name = "Taktowanie pamiêci", IsAssemblyFeature = true });
                context.Features.Add(new Core.Domain.Feature() { Id = 14, Name = "Rodzaj systemu", IsAssemblyFeature = false });
            }

            if (!context.FeatureValues.Any())
            {
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 1, Name = "Intel Core i3", FeatureId = 1 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 2, Name = "Intel Core i5", FeatureId = 1 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 3, Name = "Intel Core i7", FeatureId = 1 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 4, Name = "Socket 1150", FeatureId = 2 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 5, Name = "Socket 1151", FeatureId = 2 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 6, Name = "DDR3", FeatureId = 3 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 7, Name = "DDR4", FeatureId = 3 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 8, Name = "2", FeatureId = 4 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 9, Name = "4", FeatureId = 4 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 10, Name = "PCI-E x16", FeatureId = 5 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 11, Name = "PCI-E x8", FeatureId = 5 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 12, Name = "SATA II", FeatureId = 6 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 13, Name = "SATA III", FeatureId = 6 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 14, Name = "ATX", FeatureId = 7 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 15, Name = "mATX", FeatureId = 7 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 16, Name = "uATX", FeatureId = 7 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 17, Name = "500 GB", FeatureId = 8 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 18, Name = "1 TB", FeatureId = 8 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 19, Name = "128 GB", FeatureId = 8 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 20, Name = "256 GB", FeatureId = 8 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 21, Name = "2 GB", FeatureId = 9 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 22, Name = "4 GB", FeatureId = 9 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 23, Name = "6 GB", FeatureId = 9 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 24, Name = "8 GB", FeatureId = 9 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 25, Name = "Big Tower", FeatureId = 10 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 26, Name = "Middle Tower", FeatureId = 10 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 27, Name = "Mini Tower", FeatureId = 10 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 28, Name = "ATX", FeatureId = 11 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 29, Name = "SFX", FeatureId = 11 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 30, Name = "400 W", FeatureId = 12 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 31, Name = "500 W", FeatureId = 12 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 32, Name = "600 W", FeatureId = 12 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 33, Name = "700 W", FeatureId = 12 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 34, Name = "1600 MHz", FeatureId = 13 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 35, Name = "1866 MHz", FeatureId = 13 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 36, Name = "2133 MHz", FeatureId = 13 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 37, Name = "2400 MHz", FeatureId = 13 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 38, Name = "Windows 10", FeatureId = 14 });
                context.FeatureValues.Add(new Core.Domain.FeatureValue() { Id = 39, Name = "Mac", FeatureId = 14 });
            }

            if (!context.FeaturesForCategories.Any())
            {
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 1, FeatureId = 1, CategoryId = 6 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 2, FeatureId = 2, CategoryId = 6 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 3, FeatureId = 3, CategoryId = 6 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 4, FeatureId = 5, CategoryId = 7 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 5, FeatureId = 9, CategoryId = 7 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 6, FeatureId = 1, CategoryId = 8 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 7, FeatureId = 2, CategoryId = 8 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 8, FeatureId = 3, CategoryId = 8 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 9, FeatureId = 4, CategoryId = 8 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 10, FeatureId = 5, CategoryId = 8 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 11, FeatureId = 6, CategoryId = 8 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 12, FeatureId = 7, CategoryId = 8 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 13, FeatureId = 13, CategoryId = 8 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 14, FeatureId = 3, CategoryId = 9 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 15, FeatureId = 13, CategoryId = 9 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 16, FeatureId = 11, CategoryId = 10 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 17, FeatureId = 12, CategoryId = 10 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 18, FeatureId = 7, CategoryId = 11 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 19, FeatureId = 10, CategoryId = 11 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 20, FeatureId = 6, CategoryId = 12 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 21, FeatureId = 8, CategoryId = 12 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 22, FeatureId = 6, CategoryId = 13 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 23, FeatureId = 8, CategoryId = 13 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 24, FeatureId = 14, CategoryId = 14 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 25, FeatureId = 1, CategoryId = 15 });
                context.FeaturesForCategories.Add(new Core.Domain.FeaturesForCategory() { Id = 26, FeatureId = 2, CategoryId = 15 });
            }

            if (!context.Products.Any())
            {
                context.Products.Add(new Core.Domain.Product() { Id = 1, Name = "i3-7100 3.90GHz", Price = 469.00m, CategoryId = 6, ProducentId = 28 });
                context.Products.Add(new Core.Domain.Product() { Id = 2, Name = "i3-6100 3.70GHz", Price = 489.00m, CategoryId = 6, ProducentId = 28 });
                context.Products.Add(new Core.Domain.Product() { Id = 3, Name = "i7-7600K 3.8GHz", Price = 989.00m, CategoryId = 6, ProducentId = 28 });
                context.Products.Add(new Core.Domain.Product() { Id = 4, Name = "i5-7500 3.4GHz", Price = 839.00m, CategoryId = 6, ProducentId = 28 });
                context.Products.Add(new Core.Domain.Product() { Id = 5, Name = "i5-7400 3.00GHz", Price = 729.00m, CategoryId = 6, ProducentId = 28 });
                context.Products.Add(new Core.Domain.Product() { Id = 6, Name = "i7-7700K 4.20GHz", Price = 1449.00m, CategoryId = 6, ProducentId = 28 });
                context.Products.Add(new Core.Domain.Product() { Id = 7, Name = "i7-7700 3.60GHz", Price = 1299.00m, CategoryId = 6, ProducentId = 28 });
                context.Products.Add(new Core.Domain.Product() { Id = 8, Name = "i5-4690K 3.5GHz", Price = 999.00m, CategoryId = 6, ProducentId = 28 });
                context.Products.Add(new Core.Domain.Product() { Id = 9, Name = "GA-H81M-S2V", Price = 199.00m, CategoryId = 8, ProducentId = 18 });
                context.Products.Add(new Core.Domain.Product() { Id = 10, Name = "H81M-P33", Price = 159.00m, CategoryId = 8, ProducentId = 3 });
                context.Products.Add(new Core.Domain.Product() { Id = 11, Name = "B250M PRO-VDH", Price = 295.00m, CategoryId = 8, ProducentId = 3 });
                context.Products.Add(new Core.Domain.Product() { Id = 12, Name = "PRIME Z270-P", Price = 499.00m, CategoryId = 8, ProducentId = 4 });
                context.Products.Add(new Core.Domain.Product() { Id = 13, Name = "1TB 7200obr", Price = 209.00m, CategoryId = 13, ProducentId = 14 });
                context.Products.Add(new Core.Domain.Product() { Id = 14, Name = "500GB 7200obr", Price = 227.00m, CategoryId = 13, ProducentId = 14 });
                context.Products.Add(new Core.Domain.Product() { Id = 15, Name = "120GB SSD", Price = 249.00m, CategoryId = 12, ProducentId = 17 });
                context.Products.Add(new Core.Domain.Product() { Id = 16, Name = "256GB SSD", Price = 309.00m, CategoryId = 12, ProducentId = 16 });
                context.Products.Add(new Core.Domain.Product() { Id = 17, Name = "GeForce GTX 1060", Price = 1379.00m, CategoryId = 7, ProducentId = 18 });
                context.Products.Add(new Core.Domain.Product() { Id = 18, Name = "GeForce GTX 750 Ti", Price = 399.00m, CategoryId = 7, ProducentId = 3 });
                context.Products.Add(new Core.Domain.Product() { Id = 19, Name = "GeForce GTX 1050 Ti", Price = 689.00m, CategoryId = 7, ProducentId = 4 });
                context.Products.Add(new Core.Domain.Product() { Id = 20, Name = "Gladius M35W", Price = 209.00m, CategoryId = 11, ProducentId = 24 });
                context.Products.Add(new Core.Domain.Product() { Id = 21, Name = "Pure Base 600", Price = 289.00m, CategoryId = 11, ProducentId = 25 });
                context.Products.Add(new Core.Domain.Product() { Id = 22, Name = "Fera 3", Price = 99.00m, CategoryId = 15, ProducentId = 24 });
                context.Products.Add(new Core.Domain.Product() { Id = 23, Name = "Shadow Rock 2", Price = 189.00m, CategoryId = 15, ProducentId = 25 });
                context.Products.Add(new Core.Domain.Product() { Id = 24, Name = "500W System Power 8", Price = 209.00m, CategoryId = 10, ProducentId = 25 });
                context.Products.Add(new Core.Domain.Product() { Id = 25, Name = "600W Pure Power 10", Price = 315.00m, CategoryId = 10, ProducentId = 25 });
                context.Products.Add(new Core.Domain.Product() { Id = 26, Name = "8 GB Ballistix Sport", Price = 269.00m, CategoryId = 9, ProducentId = 22 });
                context.Products.Add(new Core.Domain.Product() { Id = 27, Name = "8 GB Ballistix Sport", Price = 279.00m, CategoryId = 9, ProducentId = 22 });
                context.Products.Add(new Core.Domain.Product() { Id = 28, Name = "4 GB Fury Black", Price = 162.00m, CategoryId = 9, ProducentId = 17 });
                context.Products.Add(new Core.Domain.Product() { Id = 29, Name = "Windows 10 Home", Price = 479.00m, CategoryId = 14, ProducentId = 7 });
            }

            if (!context.FeatureValueForProducts.Any())
            {
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 1, ProductId = 1, FeatureValueId = 1 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 2, ProductId = 1, FeatureValueId = 5 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 3, ProductId = 1, FeatureValueId = 6 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 4, ProductId = 1, FeatureValueId = 7 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 5, ProductId = 2, FeatureValueId = 1 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 6, ProductId = 2, FeatureValueId = 5 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 7, ProductId = 2, FeatureValueId = 6 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 8, ProductId = 2, FeatureValueId = 7 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 9, ProductId = 3, FeatureValueId = 2 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 10, ProductId = 3, FeatureValueId = 5 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 11, ProductId = 3, FeatureValueId = 6 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 12, ProductId = 3, FeatureValueId = 7 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 13, ProductId = 4, FeatureValueId = 2 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 14, ProductId = 4, FeatureValueId = 5 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 15, ProductId = 4, FeatureValueId = 6 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 16, ProductId = 4, FeatureValueId = 7 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 17, ProductId = 5, FeatureValueId = 2 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 18, ProductId = 5, FeatureValueId = 5 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 19, ProductId = 5, FeatureValueId = 6 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 20, ProductId = 5, FeatureValueId = 7 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 21, ProductId = 6, FeatureValueId = 3 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 22, ProductId = 6, FeatureValueId = 5 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 23, ProductId = 6, FeatureValueId = 6 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 24, ProductId = 6, FeatureValueId = 7 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 25, ProductId = 7, FeatureValueId = 3 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 26, ProductId = 7, FeatureValueId = 5 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 27, ProductId = 7, FeatureValueId = 6 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 28, ProductId = 7, FeatureValueId = 7 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 29, ProductId = 8, FeatureValueId = 2 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 30, ProductId = 8, FeatureValueId = 4 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 31, ProductId = 8, FeatureValueId = 6 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 32, ProductId = 9, FeatureValueId = 1 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 33, ProductId = 9, FeatureValueId = 2 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 34, ProductId = 9, FeatureValueId = 3 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 35, ProductId = 9, FeatureValueId = 4 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 36, ProductId = 9, FeatureValueId = 6 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 37, ProductId = 9, FeatureValueId = 8 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 38, ProductId = 9, FeatureValueId = 10 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 39, ProductId = 9, FeatureValueId = 12 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 40, ProductId = 9, FeatureValueId = 13 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 41, ProductId = 9, FeatureValueId = 16 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 42, ProductId = 9, FeatureValueId = 34 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 43, ProductId = 10, FeatureValueId = 1 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 44, ProductId = 10, FeatureValueId = 2 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 45, ProductId = 10, FeatureValueId = 3 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 46, ProductId = 10, FeatureValueId = 4 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 47, ProductId = 10, FeatureValueId = 6 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 48, ProductId = 10, FeatureValueId = 8 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 49, ProductId = 10, FeatureValueId = 10 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 50, ProductId = 10, FeatureValueId = 12 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 51, ProductId = 10, FeatureValueId = 13 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 52, ProductId = 10, FeatureValueId = 15 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 53, ProductId = 10, FeatureValueId = 34 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 54, ProductId = 11, FeatureValueId = 1 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 55, ProductId = 11, FeatureValueId = 2 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 56, ProductId = 11, FeatureValueId = 3 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 57, ProductId = 11, FeatureValueId = 5 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 58, ProductId = 11, FeatureValueId = 7 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 59, ProductId = 11, FeatureValueId = 9 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 60, ProductId = 11, FeatureValueId = 10 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 61, ProductId = 11, FeatureValueId = 13 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 62, ProductId = 11, FeatureValueId = 15 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 63, ProductId = 11, FeatureValueId = 36 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 64, ProductId = 11, FeatureValueId = 37 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 65, ProductId = 12, FeatureValueId = 1 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 66, ProductId = 12, FeatureValueId = 2 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 67, ProductId = 12, FeatureValueId = 3 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 68, ProductId = 12, FeatureValueId = 5 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 69, ProductId = 12, FeatureValueId = 7 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 70, ProductId = 12, FeatureValueId = 9 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 71, ProductId = 12, FeatureValueId = 10 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 72, ProductId = 12, FeatureValueId = 13 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 73, ProductId = 12, FeatureValueId = 14 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 74, ProductId = 12, FeatureValueId = 36 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 75, ProductId = 12, FeatureValueId = 37 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 76, ProductId = 13, FeatureValueId = 13 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 77, ProductId = 13, FeatureValueId = 18 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 78, ProductId = 14, FeatureValueId = 13 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 79, ProductId = 14, FeatureValueId = 17 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 82, ProductId = 16, FeatureValueId = 13 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 83, ProductId = 16, FeatureValueId = 20 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 84, ProductId = 15, FeatureValueId = 13 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 85, ProductId = 15, FeatureValueId = 19 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 86, ProductId = 17, FeatureValueId = 10 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 87, ProductId = 17, FeatureValueId = 23 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 88, ProductId = 18, FeatureValueId = 10 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 89, ProductId = 18, FeatureValueId = 21 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 90, ProductId = 19, FeatureValueId = 10 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 91, ProductId = 19, FeatureValueId = 22 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 92, ProductId = 20, FeatureValueId = 14 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 93, ProductId = 20, FeatureValueId = 15 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 94, ProductId = 20, FeatureValueId = 26 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 95, ProductId = 21, FeatureValueId = 14 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 96, ProductId = 21, FeatureValueId = 15 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 97, ProductId = 21, FeatureValueId = 16 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 98, ProductId = 21, FeatureValueId = 26 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 99, ProductId = 22, FeatureValueId = 1 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 100, ProductId = 22, FeatureValueId = 2 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 101, ProductId = 22, FeatureValueId = 3 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 102, ProductId = 22, FeatureValueId = 4 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 103, ProductId = 22, FeatureValueId = 5 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 104, ProductId = 23, FeatureValueId = 1 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 105, ProductId = 23, FeatureValueId = 2 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 106, ProductId = 23, FeatureValueId = 3 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 107, ProductId = 23, FeatureValueId = 4 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 108, ProductId = 23, FeatureValueId = 5 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 109, ProductId = 24, FeatureValueId = 28 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 110, ProductId = 24, FeatureValueId = 31 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 111, ProductId = 25, FeatureValueId = 28 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 112, ProductId = 25, FeatureValueId = 32 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 113, ProductId = 26, FeatureValueId = 6 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 114, ProductId = 26, FeatureValueId = 34 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 115, ProductId = 27, FeatureValueId = 7 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 116, ProductId = 27, FeatureValueId = 37 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 117, ProductId = 28, FeatureValueId = 7 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 118, ProductId = 28, FeatureValueId = 36 });
                context.FeatureValueForProducts.Add(new Core.Domain.FeatureValueForProduct() { Id = 119, ProductId = 29, FeatureValueId = 38 });
            }
        }
    }
}
