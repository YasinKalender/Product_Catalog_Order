using Product_Catalog_Order.DataAccess.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.DataAccess.Repository.Concrete
{
    public class BaseRepository<T, Tcontext> : IBaseRepository<T> where T : class where Tcontext : DbContext, new()
    {
        public void Create(T entity)
        {
            using(var context = new Tcontext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using(var context = new Tcontext())
            {

                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            using (var context =new Tcontext())
            {
                return context.Set<T>().Where(expression).ToList();

            }
        }

        public T Getbyid(int id)
        {
            using (var context=new Tcontext())
            {

                return context.Set<T>().Find(id);
            }
        }

        public T GetOne(Expression<Func<T, bool>> expression)
        {
            using (var context = new Tcontext())
            {
                return context.Set<T>().Where(expression).FirstOrDefault();

            }
        }

        public void Update(T entity)
        {
            using(var context = new Tcontext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
