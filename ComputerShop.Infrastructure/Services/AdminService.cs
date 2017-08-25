using ComputerShop.Core.Domain;
using ComputerShop.Core.Enums;
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
        private FeaturesForCategoryRepository featureForCategoryRepo;
        private ProductRepository productRepo;
        private FeatureValueForProductRepository featureValueForProductRepo;
        private UserRepository userRepo;

        public AdminService(GroupRepository groupRepo, CategoryRepository categoryRepo, ProducentRepository producentRepo, FeatureRepository featureRepo, 
                            FeatureValueRepository featureValueRepo, FeaturesForCategoryRepository featureForCategoryRepo, ProductRepository productRepo,
                            FeatureValueForProductRepository featureValueForProductRepo, UserRepository userRepo)
        {
            this.groupRepo = groupRepo;
            this.categoryRepo = categoryRepo;
            this.producentRepo = producentRepo;
            this.featureRepo = featureRepo;
            this.featureValueRepo = featureValueRepo;
            this.featureForCategoryRepo = featureForCategoryRepo;
            this.productRepo = productRepo;
            this.featureValueForProductRepo = featureValueForProductRepo;
            this.userRepo = userRepo;
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

        //Łączenie cech z kategoriami
        public IEnumerable<Feature> GetAllFeaturesAssignedForCategory(int id)
        {
            return featureForCategoryRepo.GetAll().Where(f => f.CategoryId == id).Select(c => c.Feature);
        }

        public IEnumerable<Feature> GetAllFeaturesNotAssignedForCategory(int id)
        {
            var assignedFeaturesId = GetAllFeaturesAssignedForCategory(id).Select(i => i.Id);
            var allFeaturesId = GetAllFeatures().Select(i => i.Id);
            var difference = allFeaturesId.Except(assignedFeaturesId);
            return GetAllFeatures().Where(c => difference.Contains(c.Id));
        }

        public FeaturesForCategory GetFeatureForCategory(int featureId, int categoryId)
        {
            return featureForCategoryRepo.GetAll().Where(f => (f.FeatureId == featureId && f.CategoryId == categoryId)).SingleOrDefault();
        }

        public void AssignFeaturesToCategory(int categoryId, IEnumerable<int> featuresId)
        {
            foreach (var featureId in featuresId)
            {
                featureForCategoryRepo.Insert(new FeaturesForCategory() { CategoryId = categoryId, FeatureId = featureId });
            }
        }

        public void DeleteAssignFeaturesToCategory(int categoryId, IEnumerable<int> featuresId)
        {
            foreach(var featureId in featuresId)
            {
                featureForCategoryRepo.Delete(GetFeatureForCategory(featureId, categoryId));
            }
        }

        //metody dla produktów
        public IEnumerable<Product> GetAllProducts()
        {
            return productRepo.GetAll();
        }

        public Product GetProductById(int productId)
        {
            return productRepo.Get(productId);
        }

        public void AddNewProduct(Product product)
        {
            productRepo.Insert(product);
        }

        public void DeleteProduct(int productId)
        {
            productRepo.Delete(productRepo.Get(productId));
        }

        public void EditProduct(Product product)
        {
            productRepo.Update(product);
        }

        public IEnumerable<Feature> GetAllFeaturesForProductId(int productId)
        {
            return productRepo.Get(productId).Category.FeatureForCategory.Select(f => f.Feature);
        }

        public void AssignVeatureValueToProduct(int productId, IEnumerable<int> featureValueIds)
        {
            var featureValues = featureValueForProductRepo.GetAll().Where(f => f.ProductId == productId);
            if (featureValues != null)
            {
                foreach (var item in featureValues)
                {
                    featureValueForProductRepo.Remove(item);
                }
                featureValueForProductRepo.SaveChanges();
            }
            foreach (var item in featureValueIds)
            {
                featureValueForProductRepo.Insert(new FeatureValueForProduct() { ProductId = productId, FeatureValueId = item });
            }
        }

        public IEnumerable<FeatureValueForProduct> GetAllFeatureValuesForProductId(int productId)
        {
            return featureValueForProductRepo.GetAll().Where(p => p.ProductId == productId);
        }

        //Metody dla klientów
        public IEnumerable<User> GetAllCustomers()
        {
            var roleProvider = System.Web.Security.Roles.Provider;
            var usersInRole = roleProvider.GetUsersInRole(ShopRoles.Customer.ToString());
            return userRepo.GetAll().Where(u => usersInRole.Contains(u.Email)).ToList();
        }

        public void AssignSellerRoleToUserById(int userId)
        {
            var roleProvider = System.Web.Security.Roles.Provider;
            User user = userRepo.Get(userId);
            roleProvider.AddUsersToRoles(new[] { user.Email }, new[] { ShopRoles.Seller.ToString() });
        }

        //Metody dla sprzedawców
        public IEnumerable<User> GetAllSellers()
        {
            var roleProvider = System.Web.Security.Roles.Provider;
            var usersInRole = roleProvider.GetUsersInRole(ShopRoles.Seller.ToString());
            return userRepo.GetAll().Where(u => usersInRole.Contains(u.Email)).ToList();
        }

        public void RemoveSellerRoleFromUser(int userId)
        {
            var roleProvider = System.Web.Security.Roles.Provider;
            User user = userRepo.Get(userId);
            roleProvider.RemoveUsersFromRoles(new[] { user.Email }, new[] { ShopRoles.Seller.ToString() });
        }
    }
}
