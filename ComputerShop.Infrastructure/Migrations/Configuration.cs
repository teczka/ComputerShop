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
            //Add admin account
            if (!WebSecurity.UserExists("admin@admin.pl"))
            {
                WebSecurity.CreateUserAndAccount("admin@admin.pl", "haslo1", new { Name = "Admin", Surname = "Systemu", PhoneNumber = "123456789" });
                rolesProvider.AddUsersToRoles(new[] { "admin@admin.pl" }, new[] { "Admin"});
            }
        }
    }
}
