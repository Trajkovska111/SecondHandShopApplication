using SecondHandShop.Domain.DomainModels;
using System;

namespace SecondHandShop.Domain.DTO
{
    public class AddToShoppingCardDto
    {
        public Product SelectedProduct { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
