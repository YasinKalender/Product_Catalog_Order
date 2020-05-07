using Product_Catalog_Order.DAL.Context;
using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using Product_Catalog_Order.DataAccess.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.DataAccess.Repository.Concrete
{
    public class CategoryRepository:BaseRepository<Category,ProjectContext>,ICategoryRepository
    {
    }
}
