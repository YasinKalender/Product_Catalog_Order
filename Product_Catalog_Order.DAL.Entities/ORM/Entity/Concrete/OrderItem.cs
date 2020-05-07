using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete
{
    public class OrderItem:BaseEntity
    {
        public int Qantity { get; set; }
        public decimal  Price { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public int OrderID { get; set; }

        public virtual Order Order { get; set; }
    }
}
