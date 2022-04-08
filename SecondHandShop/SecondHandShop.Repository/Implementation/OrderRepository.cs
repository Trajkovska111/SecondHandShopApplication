using Microsoft.EntityFrameworkCore;
using SecondHandShop.Domain.DomainModels;
using SecondHandShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondHandShop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        //string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }


        public List<Order> getAllOrders()
        {
            return entities
                .Include(z => z.User)
                .Include(z => z.ProductInOrders)
                .Include("ProductInOrders.OrderedProduct")
                .ToListAsync().Result;
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return entities
               .Include(z => z.User)
               .Include(z => z.ProductInOrders)
               .Include("ProductInOrders.OrderedProduct")
               .SingleOrDefaultAsync(z => z.Id == model.Id).Result;
        }
    }
}
