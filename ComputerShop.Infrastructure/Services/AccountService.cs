using ComputerShop.Core.Domain;
using ComputerShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.WebData;

namespace ComputerShop.Infrastructure.Services
{
    public class AccountService
    {
        public void RegisterUser(User user, string password)
        {
            WebSecurity.CreateUserAndAccount(user.Email, password, new { Surname = user.Surname, Name = user.Name, PhoneNumber = user.PhoneNumber });
        }

        public void LoginUser(string email, string password)
        {
            WebSecurity.Login(email, password);
        }

        public void LogoutUser()
        {
            WebSecurity.Logout();
        }

        public void AssignToRole(string userEmail, ShopRoles role)
        {
            if (WebSecurity.UserExists(userEmail))
            {
                var roleProvider = System.Web.Security.Roles.Provider;
                roleProvider.AddUsersToRoles(new[] { userEmail }, new[] { role.ToString() });
            }            
        }
    }
}
