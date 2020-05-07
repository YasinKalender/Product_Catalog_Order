using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.DataAccess.Repository.Abstract
{
    public interface IBaseRepository<T>
    {
        T Getbyid(int id);

        List<T> GetAll(Expression<Func<T, bool>> expression);

        T GetOne(Expression<Func<T, bool>> expression);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
