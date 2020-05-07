using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete
{
    public class Product:BaseEntity
    {

        public string ProductName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
