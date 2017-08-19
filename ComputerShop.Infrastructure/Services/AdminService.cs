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
        private ProducentRepository producentRepo;
        private FeatureRepository featureRepo;
        private FeatureValueRepository featureValueRepo;

        public AdminService(GroupRepository groupRepo, CategoryRepository categoryRepo, ProducentRepository producentRepo,
                            FeatureRepository featureRepo, FeatureValueRepository featureValueRepo)
        {
            this.groupRepo = groupRepo;
            this.categoryRepo = categoryRepo;
            this.producentRepo = producentRepo;
            this.featureRepo = featureRepo;
            this.featureValueRepo = featureValueRepo;
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

        //Metody dla producentów
        public IEnumerable<Producent> GetAllProducents()
        {
            return producentRepo.GetAll();
        }

        public Producent GetProducentById(int id)
        {
            return producentRepo.Get(id);
        }

        public void AddNewProducent(Producent producent)
        {
            producentRepo.Insert(producent);
        }

        public void EditProducent(Producent producent)
        {
            producentRepo.Update(producent);
        }

        public void DeleteProducent(int producentId)
        {
            var localProducent = GetProducentById(producentId);
            producentRepo.Delete(localProducent);
        }

        //Metody dla cech
        public IEnumerable<Feature> GetAllFeatures()
        {
            return featureRepo.GetAll();
        }

        public Feature GetFeatureById(int id)
        {
            return featureRepo.Get(id);
        }

        public void AddNewFeature(Feature feature)
        {
            featureRepo.Insert(feature);
        }

        public void EditFeature(Feature feature)
        {
            featureRepo.Update(feature);
        }

        public void DeleteFeature(int id)
        {
            var localFeature = GetFeatureById(id);
            featureRepo.Delete(localFeature);
        }

        public IEnumerable<FeatureValue> GetFeatureValuesForFeatureId(int featureId)
        {
            return featureValueRepo.GetAll().Where(f => f.FeatureId == featureId);
        }

        public FeatureValue GetFeatureValueById(int id)
        {
            return featureValueRepo.Get(id);
        }

        public void AddNewFeatureValue(FeatureValue featureValue)
        {
            featureValueRepo.Insert(featureValue);
        }

        public void EditFeatureValue(FeatureValue featureValue)
        {
            featureValueRepo.Update(featureValue);
        }

        public void DeleteFeatureValue(int featureValueId)
        {
            var localFeatureValue = featureValueRepo.Get(featureValueId);
            featureValueRepo.Delete(localFeatureValue);
        }
    }
}
