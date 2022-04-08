using SecondHandShop.Domain.DomainModels;
using SecondHandShop.Repository.Interface;
using SecondHandShop.Services.Interface;
using System.Collections.Generic;

namespace SecondHandShop.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public List<Order> getAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return this._orderRepository.getOrderDetails(model);
        }
    }
}
