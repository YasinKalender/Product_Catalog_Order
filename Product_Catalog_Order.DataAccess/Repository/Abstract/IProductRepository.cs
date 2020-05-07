using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.DataAccess.Repository.Abstract
{
    public interface IProductRepository:IBaseRepository<Product>
    {

        Product GetProduct(Expression<Func<Product, bool>> expression);
    }
}
