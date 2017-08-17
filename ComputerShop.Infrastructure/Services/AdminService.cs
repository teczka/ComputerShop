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


        //Metody dla Grup
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

        public void EditGroup(Group group)
        {
            groupRepo.Update(group);
        }

        public void DeleteGroup(int groupId)
        {
            var localGroup = GetGroupById(groupId);
            groupRepo.Delete(localGroup);
        }

        //Metody dla Kategorii
        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepo.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return categoryRepo.Get(id);
        }

        public void AddNewCategory(Category category)
        {
            categoryRepo.Insert(category);
        }

        public void EditCategory(Category category)
        {
            categoryRepo.Update(category);
        }

        public void DeleteCategory(int categoryId)
        {
            var localCategory = GetCategoryById(categoryId);
            categoryRepo.Delete(localCategory);
        }
    }
}
