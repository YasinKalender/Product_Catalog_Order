using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.Mapping.Option
{
    public class CoreMap<T>:EntityTypeConfiguration<T> where T :BaseEntity
    {
        public CoreMap()
        {
            Property(i => i.ID).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity).IsRequired();
            Property(i => i.AddDate).HasColumnName("AddDate").IsRequired();
            Property(i => i.DeleteDate).HasColumnName("DeleteDate").IsOptional();
            Property(i => i.UpdateDate).HasColumnName("UpdateDate").IsOptional();
            Property(i => i.Status).HasColumnName("Status").IsRequired();

        }


    }
}
