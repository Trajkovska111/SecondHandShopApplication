using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondHandShop.Domain.DomainModels;
using SecondHandShop.Domain.Identity;
using SecondHandShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandShop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IOrderService _orderService;
        //private readonly UserManager<ApplicationUser> userManager;

        public AdminController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            this._orderService = orderService;
            //this.userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrders()
        {
            return this._orderService.getAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetDetailsForProduct(BaseEntity model)
        {
            return this._orderService.getOrderDetails(model);
        }

    }
}
