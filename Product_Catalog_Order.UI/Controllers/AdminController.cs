using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Catalog_Order.UI.Controllers
{

    [Authorize(Roles ="Admin")]
    public class AdminController : BaseController
    {
        // GET: Admin

        public ActionResult AdminIndex()
        {


            return View();
        }

        public ActionResult CategoryList()
        {

            return View(categoryRepository.GetAll(i=>i.Status==DAL.Entities.ORM.Entity.Enum.Status.Active || i.Status==DAL.Entities.ORM.Entity.Enum.Status.Update).ToList());

        }
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {

            if (ModelState.IsValid)
            {
                categoryRepository.Create(category);
                return Redirect("~/Admin/CategoryList");
            }
            return View(category);
        }

        public ActionResult CategoryEdit(int id)
        {
            var category = categoryRepository.Getbyid(id);

            return View(category);
        }


        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {
            if (ModelState.IsValid)
            {
                category.UpdateDate = DateTime.Now;
                category.Status = DAL.Entities.ORM.Entity.Enum.Status.Update;
                categoryRepository.Update(category);
                return Redirect("~/Admin/CategoryList");
            }

            return View(category);
        }

        public ActionResult CategoryDelete(int id)
        {
            var category = categoryRepository.Getbyid(id);

            if (category!=null)
            {
                categoryRepository.Delete(category);
                return Redirect("~/Admin/CategoryList");
            }

            return View();
        }

        public ActionResult ProductList()
        {


            return View(productRepository.GetAll(i=>i.Status==DAL.Entities.ORM.Entity.Enum.Status.Active || i.Status==DAL.Entities.ORM.Entity.Enum.Status.Update).ToList());
        }

        public ActionResult ProductAdd()
        {

            List<SelectListItem> selectListItems = categoryRepository.GetAll(i => i.Status == DAL.Entities.ORM.Entity.Enum.Status.Active || i.Status == DAL.Entities.ORM.Entity.Enum.Status.Update).Select(i => new SelectListItem() { Text = i.CategoryName, Value = i.ID.ToString() }).ToList();
            ViewBag.category = selectListItems;

            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product product,HttpPostedFileBase file)
        {

            if (file!=null)
            {
                product.Image = file.FileName;
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Image/"+filename));

                file.SaveAs(path);
            }

            if (ModelState.IsValid)
            {
                productRepository.Create(product);
                return Redirect("/Admin/ProductList");
            }

            return View(product);
        }

        public ActionResult ProductEdit(int id)
        {
            var product = productRepository.Getbyid(id);
            List<SelectListItem> selectListItems = categoryRepository.GetAll(i => i.Status == DAL.Entities.ORM.Entity.Enum.Status.Active || i.Status == DAL.Entities.ORM.Entity.Enum.Status.Update).Select(i => new SelectListItem() { Text = i.CategoryName, Value = i.ID.ToString() }).ToList();
            ViewBag.category = selectListItems;

            return View(product);
        }

        [HttpPost]
        public ActionResult ProductEdit(Product product,HttpPostedFileBase file)
        {
            if (file!=null)
            {
                product.Image = file.FileName;

                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("/Image/") + filename);
                file.SaveAs(path);
            }

            if (ModelState.IsValid)
            {
                product.UpdateDate = DateTime.Now;
                product.Status = DAL.Entities.ORM.Entity.Enum.Status.Update;
                productRepository.Update(product);
                return Redirect("/Admin/ProductList");
            }

            return View();
        }

        public ActionResult ProductDelete(int id)
        {
            var product = productRepository.Getbyid(id);

            if (product!=null)
            {
                productRepository.Delete(product);
                return Redirect("/Admin/ProductList");
            }

            return View();
        }
    }
}