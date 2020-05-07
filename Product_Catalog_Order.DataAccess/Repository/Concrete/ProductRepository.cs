using Product_Catalog_Order.DAL.Context;
using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using Product_Catalog_Order.DataAccess.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.DataAccess.Repository.Concrete
{
    public class ProductRepository : BaseRepository<Product, ProjectContext>, IProductRepository
    {
        public Product GetProduct(Expression<Func<Product, bool>> expression)
        {
            using(var context = new ProjectContext())
            {
                return context.Products.FirstOrDefault(expression);

            }
        }
    }
}
