using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.Mapping.Option
{
    public class ProductMap:CoreMap<Product>
    {

        public ProductMap()
        {
            Property(i => i.ProductName).HasMaxLength(255).IsRequired();
            Property(i => i.Description).HasMaxLength(255).IsRequired();
            Property(i => i.Image).IsOptional();
            Property(i => i.Price).IsRequired();
            Property(i => i.Stock).IsRequired();


            HasRequired(i => i.Category)
                .WithMany(i => i.Products)
                .HasForeignKey(i => i.CategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}
