using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.DataAccess.Repository.Abstract
{
    interface IOrderRepository:IBaseRepository<Order>
    {
        List<Order> GetOrders(Expression<Func<Order, bool>> expression);

        Order GetOrder(Expression<Func<Order, bool>> expression);
    }
}
