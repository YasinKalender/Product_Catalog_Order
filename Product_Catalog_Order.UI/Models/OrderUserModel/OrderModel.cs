using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using Product_Catalog_Order.DAL.Entities.ORM.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Catalog_Order.UI.Models.OrderUserModel
{
    public class OrderModel:BaseEntity
    {


        public string UserName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }

        public string Region { get; set; }

        public string PostaCode { get; set; }

        public string OrderNumber { get; set; }

        public decimal Total { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}