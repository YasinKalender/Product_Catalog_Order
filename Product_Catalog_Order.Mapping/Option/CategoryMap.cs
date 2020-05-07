using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.Mapping.Option
{
    public class CategoryMap:CoreMap<Category>
    {

        public CategoryMap()
        {
            Property(i => i.CategoryName).HasMaxLength(255).IsRequired();
            Property(i => i.Description).HasMaxLength(255).IsRequired();


            HasMany(i => i.Products)
                .WithRequired(i => i.Category)
                .HasForeignKey(i => i.CategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}
