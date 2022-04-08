using SecondHandShop.Domain.DomainModels;
using SecondHandShop.Domain.DTO;
using System;
using System.Collections.Generic;

namespace SecondHandShop.Services.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        List<Product> GetClothes();
        List<Product> GetShoes();
        List<Product> GetHandbags();
        List<Product> GetAccesories();
        Product GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Product p);
        void UpdeteExistingProduct(Product p);
        AddToShoppingCardDto GetShoppingCartInfo(Guid? id);
        void DeleteProduct(Guid id);
        bool AddToShoppingCart(AddToShoppingCardDto item, string userID);
    }
}
