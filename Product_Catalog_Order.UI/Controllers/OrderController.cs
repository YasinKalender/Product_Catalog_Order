using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using Product_Catalog_Order.DAL.Entities.ORM.Entity.Enum;
using Product_Catalog_Order.DataAccess.Repository.Concrete;
using Product_Catalog_Order.UI.Models.OrderUserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Catalog_Order.UI.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        // GET: Order

        OrderRepository orderRepository;
        public OrderController()
        {
            orderRepository = new OrderRepository();
        }
        public ActionResult Index()
        {
            var username = User.Identity.Name;

            return View(orderRepository.GetOrders(i => i.UserName == username).Select(i => new OrderModel
            {

                ID = i.ID,
                UserName = i.UserName,
                Adress = i.Adress,
                AddDate = i.AddDate,
                City = i.City,
                OrderNumber = i.OrderNumber,
                OrderStatus = i.OrderStatus,
                PostaCode = i.PostaCode,
                Region = i.Region,
                Status = i.Status,
                Total = i.Total

            }).ToList());
        }

        public ActionResult OrderDetails(int id)
        {


            return View(orderRepository.GetOrder(i => i.ID == id));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminOrder()
        {

            return View(orderRepository.GetAll(i => i.OrderStatus == DAL.Entities.ORM.Entity.Enum.OrderStatus.Complete || i.OrderStatus == DAL.Entities.ORM.Entity.Enum.OrderStatus.Waiting).ToList());

           
        }

        public ActionResult AdminOrderDetails(int id)
        {


            return View(orderRepository.GetOrder(i => i.ID == id));
        }

        
        public ActionResult UpdateOrder(int id, OrderStatus orderStatus)
        {
            var order = db.Orders.Where(i => i.ID == id).FirstOrDefault();

            if (order != null)
            {
                order.OrderStatus = orderStatus;
                db.SaveChanges();

                return RedirectToAction("AdminOrder", new { id = order.ID });
            }
            return View();
        }
    }
}