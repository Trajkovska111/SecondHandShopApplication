using SecondHandShop.Domain.Identity;
using System;
using System.Collections.Generic;

namespace SecondHandShop.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {

        public ApplicationUser Owner { get; set; }
        public String OwnerId { get; set; }
        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
            
     }
}
