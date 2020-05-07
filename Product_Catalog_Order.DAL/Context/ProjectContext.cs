using Product_Catalog_Order.DAL.Data;
using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using Product_Catalog_Order.Mapping.Option;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.DAL.Context
{
    public class ProjectContext:DbContext
    {

        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=(localdb)\MSSQLLocalDB; Database=Product_Catalog_Order; integrated security=true";
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
