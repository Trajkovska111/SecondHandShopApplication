using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandShopAdminApplication.Models
{
    public class Product
    {
        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public string ProductDescription { get; set; }

        public int Price { get; set; }

        public int Rating { get; set; }
    }
}
