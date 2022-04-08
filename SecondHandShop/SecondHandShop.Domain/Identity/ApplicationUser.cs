using Microsoft.AspNetCore.Identity;
using SecondHandShop.Domain.DomainModels;

namespace SecondHandShop.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual ShoppingCart UserShoppingCart { get; set; }

    }
}
