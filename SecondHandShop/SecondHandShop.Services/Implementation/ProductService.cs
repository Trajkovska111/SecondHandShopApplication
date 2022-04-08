using SecondHandShop.Domain.DomainModels;
using SecondHandShop.Domain.DTO;
using SecondHandShop.Repository.Interface;
using SecondHandShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondHandShop.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
       // private readonly ILogger<ProductService> _logger;
        public ProductService(IRepository<Product> productRepository, IRepository<ProductInShoppingCart> productInShoppingCartRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
          //  _logger = logger;
        }

        public bool AddToShoppingCart(AddToShoppingCardDto item, string userID)
        {

            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserShoppingCart;

            if (item.ProductId != null && userShoppingCard != null)
            {
                var product = this.GetDetailsForProduct(item.ProductId);

                if (product != null)
                {
                    ProductInShoppingCart itemToAdd = new ProductInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        ProductId = product.Id,
                        ShoppingCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    this._productInShoppingCartRepository.Insert(itemToAdd);
                    //_logger.LogInformation("Product was successfully added into ShoppingCart");
                    return true;
                }
                return false;
            }
            //_logger.LogInformation("Something was wrong. ProductId or UserShoppingCard may be unaveliable!");
            return false;
        }

        public void CreateNewProduct(Product p)
        {
            this._productRepository.Insert(p);
        }

        public void DeleteProduct(Guid id)
        {
            var product = this.GetDetailsForProduct(id);
            this._productRepository.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            //_logger.LogInformation("GetAllProducts was called!");
            List<Product> products = this._productRepository.GetAll().ToList();
            return products;
        }

        public List<Product> GetClothes()
        {
            List<Product> allProducts = this.GetAllProducts();
            List<Product> clothes = allProducts.Where(p => p.ProductDescription.Equals("Clothes") || p.ProductDescription.Equals("clothes")).ToList();
            return clothes;
        }

        public List<Product> GetShoes()
        {
            List<Product> allProducts = this.GetAllProducts();
            List<Product> shoes = allProducts.Where(p => p.ProductDescription.Equals("Shoes") || p.ProductDescription.Equals("shoes")).ToList();
            return shoes;
        }

        public List<Product> GetAccesories()
        {
            List<Product> allProducts = this.GetAllProducts();
            List<Product> acc = allProducts.Where(p => p.ProductDescription.Equals("Accesories") || p.ProductDescription.Equals("accesories")).ToList();
            return acc;
        }

        public List<Product> GetHandbags()
        {
            List<Product> allProducts = this.GetAllProducts();
            List<Product> handbags = allProducts.Where(p => p.ProductDescription.Equals("Handbags") || p.ProductDescription.Equals("handbags")).ToList();
            return handbags;
        }

        public Product GetDetailsForProduct(Guid? id)
        {
            return this._productRepository.Get(id);
        }

        public AddToShoppingCardDto GetShoppingCartInfo(Guid? id)
        {
            var product = this.GetDetailsForProduct(id);
            AddToShoppingCardDto model = new AddToShoppingCardDto
            {
                SelectedProduct = product,
                ProductId = product.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdeteExistingProduct(Product p)
        {
            this._productRepository.Update(p);
        }
    }
}
