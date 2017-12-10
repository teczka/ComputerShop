using ComputerShop.Core.Domain;
using ComputerShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Services
{
    public class AssemblyService
    {
        private CategoryRepository categoryRepo;
        private ProductRepository productRepo;
        private AssemblyRepository assemblyRepo;
        private FeatureRepository featureRepo;
        private FeaturesForCategoryRepository featuresForCategoryRepo;
        private FeatureValueRepository featureValueRepo;
        private UserRepository userRepo;

        public AssemblyService(ComputerShopContext context)
        {
            categoryRepo = new CategoryRepository(context);
            productRepo = new ProductRepository(context);
            assemblyRepo = new AssemblyRepository(context);
            featureRepo = new FeatureRepository(context);
            featuresForCategoryRepo = new FeaturesForCategoryRepository(context);
            featureValueRepo = new FeatureValueRepository(context);
            userRepo = new UserRepository(context);
        }

        public IEnumerable<Category> GetAssemblyCategories()
        {
            return categoryRepo.GetAll().Where(c => c.IsAssemblyCategory == true);
        }

        public IEnumerable<Product> GetMatchingProductsForCategory(int userId, int categoryId)
        {
            Assembly currentAssembly = GetCurrentAssembly(userId);
            if (currentAssembly.Products.Count == 0)
            {
                return productRepo.GetAll().Where(p => p.CategoryId == categoryId);
            }
            else
            {
                List<int> allFeatureValuesInAssembly = new List<int>();
                foreach (var product in currentAssembly.Products)
                {
                    allFeatureValuesInAssembly.AddRange(GetFeatureValuesForProduct(product.Id));
                }
                var result = productRepo.GetAll().Where(p => p.CategoryId == categoryId && IsAnyFeatureValueEqual(allFeatureValuesInAssembly, p.FeatureValuesForProduct.Select(f => f.FeatureValueId).ToList()) == true);
                if (result.FirstOrDefault() == null)
                {
                    return productRepo.GetAll().Where(p => p.CategoryId == categoryId);
                }
                else
                    return result;
            }
        }

        public Assembly GetCurrentAssembly(int userId)
        {
            var assembly = assemblyRepo.GetAll().Where(a => a.UserId == userId && a.IsFinished == false).SingleOrDefault();
            if (assembly == null)
            {
                CreateNewAssembly(userId);
                return assemblyRepo.GetAll().Where(a => a.UserId == userId && a.IsFinished == false).SingleOrDefault();
            }
            else
                return assembly;
        }

        public void CreateNewAssembly(int userId)
        {
            var assembly = new Assembly()
            {
                User = userRepo.Get(userId),
                UserId = userId
            };
            assemblyRepo.Insert(assembly);
        }

        public void AddProductToAssembly(int productId, int assemblyId)
        {
            var assembly = assemblyRepo.Get(assemblyId);
            var productToAdd = productRepo.Get(productId);
            assembly.Products.Add(productToAdd);
            assemblyRepo.Update(assembly);
        }

        private IEnumerable<int> GetFeatureValuesForProduct(int productId)
        {
            return productRepo.Get(productId).FeatureValuesForProduct.Select(p => p.FeatureValueId);
        }

        private bool IsAnyFeatureValueEqual(List<int> allFeatureValues, List<int> productFeatureValues)
        {
            return productFeatureValues.Intersect(allFeatureValues).Any();
        }

        public void FinishCurrentAssembly(int userId)
        {
            var currentAssembly = assemblyRepo.GetAll().Where(a => a.UserId == userId && a.IsFinished == false).FirstOrDefault();
            currentAssembly.IsFinished = true;
            assemblyRepo.Update(currentAssembly);
        }

        public void SetAssemblyRole(string AssemblyRole, string assemblyId)
        {
            int asmId = int.Parse(assemblyId);
            var assembly = assemblyRepo.Get(asmId);
            assembly.AssemblyRole = (Core.Enums.AssemblyRole)Enum.Parse(typeof(Core.Enums.AssemblyRole), AssemblyRole);
            assemblyRepo.Update(assembly);
        }

        public List<Assembly> GetListOfFinishedAssemblies()
        {
            return assemblyRepo.GetAll().Where(a => a.IsFinished == true).ToList();
        }

        public void AddComment(int assemblyId, int userId, string text, string grade)
        {
            var assembly = assemblyRepo.Get(assemblyId);
            var user = userRepo.Get(userId);
            assembly.Comments.Add(new Comment()
            {
                AddDate = DateTime.Now,
                Assembly = assembly,
                AssemblyGrade = (Core.Enums.AssemblyGrade)Enum.Parse(typeof(Core.Enums.AssemblyGrade), grade),
                AssemblyId = assemblyId,
                Content = text,
                UserId = userId,
                User = user
            });
            assemblyRepo.Update(assembly);
        }

        public Assembly GetAsseblyById(int id)
        {
            return assemblyRepo.Get(id);
        }
    }
}
