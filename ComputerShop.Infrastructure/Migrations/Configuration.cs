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
                context.Features.Add(new Core.Domain.Feature() { Id = 1, Name = "Interfejs dysku" });
                context.Features.Add(new Core.Domain.Feature() { Id = 2, Name = "Rodzaj z³¹cza karty graficznej" });
                context.Features.Add(new Core.Domain.Feature() { Id = 1, Name = "Socket" });
            }
        }
    }
}
