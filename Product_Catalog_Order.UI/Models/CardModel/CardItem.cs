using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Catalog_Order.UI.Models.CardModel
{
    public class CardItem
    {

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}