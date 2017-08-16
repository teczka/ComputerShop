using ComputerShop.Core.Domain;
using ComputerShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Services
{
    public class AdminService
    {
        private GroupRepository groupRepo;
        private CategoryRepository categoryRepo;

        public AdminService(GroupRepository groupRepo, CategoryRepository categoryRepo)
        {
            this.groupRepo = groupRepo;
            this.categoryRepo = categoryRepo;
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return groupRepo.GetAll();
        }

        public Group GetGroupById(int id)
        {
            return groupRepo.Get(id);
        }

        public void AddNewGroup(Group group)
        {
            groupRepo.Insert(group);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepo.GetAll();
        }


    }
}
