using ComputerShop.Core.Domain;
using ComputerShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Infrastructure.Services
{
    public class ShopService
    {
        private ProductRepository productRepo;
        private CategoryRepository categoryRepo;
        private BasketRepository basketRepo;
        private UserRepository userRepo;
        private BasketItemRepository basketItemRepo;
        private OrderRepository orderRepo;
        private AddressRepository addressRepo;

        public ShopService(ComputerShopContext context)
        {
            productRepo = new ProductRepository(context);
            categoryRepo = new CategoryRepository(context);
            basketRepo = new BasketRepository(context);
            userRepo = new UserRepository(context);
            basketItemRepo = new BasketItemRepository(context);
            orderRepo = new OrderRepository(context);
            addressRepo = new AddressRepository(context);
        }

        public IEnumerable<Product> GetProducts(PageInfo pageInfo, int groupId = 0, int categoryId = 0)
        {
            int productsToSkip = pageInfo.ItemsPerPage * (pageInfo.CurrentPage - 1);
            if (groupId == 0)
            {
                if (categoryId == 0)
                {
                    return productRepo.GetAll().Skip(productsToSkip);
                }
                else
                {
                    return productRepo.GetAll().Where(p => p.CategoryId == categoryId).Skip(productsToSkip);
                }
            }
            else
            {
                return productRepo.GetAll().Where(p => p.Category.GroupId == groupId).Skip(productsToSkip);
            }
            
        }

        public PageInfo GetPageInfo(int groupId = 0, int categoryId = 0, int currentPage = 1)
        {
            if (groupId == 0)
            {
                if (categoryId == 0)
                {
                    return new PageInfo()
                    {
                        CurrentPage = currentPage,
                        ItemsPerPage = 10,
                        TotalItems = productRepo.GetAll().Count()
                    };
                }
                else
                {
                    return new PageInfo()
                    {
                        CurrentPage = currentPage,
                        ItemsPerPage = 10,
                        TotalItems = productRepo.GetAll().Where(p => p.CategoryId == categoryId).Count()
                    };
                }  
            }
            else
            {
                return new PageInfo()
                {
                    CurrentPage = currentPage,
                    ItemsPerPage = 10,
                    TotalItems = productRepo.GetAll().Where(p => p.Category.GroupId == groupId).Count()
                };
            }
        }

        public void AddProductToBasket(int productId, int userId)
        {
            var basketItems = new List<BasketItem>();
            basketItems.Add(new BasketItem() { ProductId = productId, AmountOfProducts = 1 });
            var basket = basketRepo.GetAll().Where(b => (b.IsClosed == false && b.UserId == userId)).FirstOrDefault();
            if (basket == null)
            {
                basketRepo.Insert(new Basket()
                {
                    IsClosed = false,
                    UserId = userId,
                    BasketItems = basketItems
                });
            }
            else
            {
                var editBasketItem = basket.BasketItems.Where(b => b.ProductId == productId).FirstOrDefault();
                if (editBasketItem == null)
                {
                    basket.BasketItems.Add(new BasketItem() { ProductId = productId, AmountOfProducts = 1 });
                }
                else
                {
                    editBasketItem.AmountOfProducts++;
                }
                
                basketRepo.Update(basket);
            }
        }

        public Basket GetOpenBasketForUserId(int userId)
        {
            return basketRepo.GetAll().Where(b => (b.UserId == userId && b.IsClosed == false)).FirstOrDefault();
        }

        public void RemoveItemFromBasket(int basketId, int productId)
        {
            var basket = basketRepo.Get(basketId);
            var itemToRemove = basketItemRepo.GetAll().Where(b => (b.Basket.Id == basketId && b.ProductId == productId)).FirstOrDefault();
            basketItemRepo.Delete(itemToRemove);
        }

        public Basket GetBasketById(int basketId)
        {
            return basketRepo.Get(basketId);
        }

        public void CreateOrder(int basketId, Address address)
        {
            var basket = GetBasketById(basketId);
            orderRepo.Insert(new Order()
            {
                Address = new Address() { City = address.City, Line = address.Line, PostCode = address.PostCode },
                OrderDate = DateTime.Now,
                BasketId = basket.Id,
                Basket = basket
            });
            basket.IsClosed = true;
            basketRepo.SaveChanges();
        }
    }
}
