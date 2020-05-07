using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Catalog_Order.UI.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(productRepository.GetAll(i=>i.Status==DAL.Entities.ORM.Entity.Enum.Status.Active || i.Status==DAL.Entities.ORM.Entity.Enum.Status.Update).ToList());
        }

        public ActionResult Details(int id)
        {
            var product = productRepository.Getbyid(id);

            return View(product);
        }

        public ActionResult List(int? id)
        {
            var product = productRepository.GetAll(i => i.Status == DAL.Entities.ORM.Entity.Enum.Status.Active || i.Status == DAL.Entities.ORM.Entity.Enum.Status.Update).AsQueryable();

            if (id!=null)
            {
                 product = product.Where(i => i.CategoryID == id);
            }

            return View(product.ToList());
        }


        [ChildActionOnly]
        public PartialViewResult GetCategory()
        {


            return PartialView(categoryRepository.GetAll(i => i.Status == DAL.Entities.ORM.Entity.Enum.Status.Active || i.Status == DAL.Entities.ORM.Entity.Enum.Status.Update).ToList());
        }
    }
}