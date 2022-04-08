using SecondHandShop.Domain.Identity;
using System.Collections.Generic;

namespace SecondHandShop.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public IEnumerable<ProductInOrder> ProductInOrders { get; set; }
    }
}
