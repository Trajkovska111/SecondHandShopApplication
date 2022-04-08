using SecondHandShop.Domain.DomainModels;
using System.Collections.Generic;
namespace SecondHandShop.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> getAllOrders();
        Order getOrderDetails(BaseEntity model);
    }
}
