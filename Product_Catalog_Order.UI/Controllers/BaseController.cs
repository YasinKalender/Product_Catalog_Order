using Product_Catalog_Order.DAL.Context;
using Product_Catalog_Order.DataAccess.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Catalog_Order.UI.Controllers
{
    public class BaseController : Controller
    {
        public ProductRepository productRepository;
        public CategoryRepository categoryRepository;
        public ProjectContext db;


        public BaseController()
        {
            productRepository = new ProductRepository();
            categoryRepository = new CategoryRepository();
            db = new ProjectContext();

        }

    }
}