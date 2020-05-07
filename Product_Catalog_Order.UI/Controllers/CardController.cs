using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using Product_Catalog_Order.UI.Models.CardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Catalog_Order.UI.Controllers
{
    public class CardController : BaseController
    {
        // GET: Card
        public ActionResult Index()
        {
            return View(GetCard());
        }

        public ActionResult AddToProduct(int id)
        {
            var product = productRepository.GetProduct(i => i.ID == id);

            if (product != null)
            {
                GetCard().AddToProduct(product, 1);
            }
            return Redirect("Index");
        }

        public ActionResult DeleteToProduct(int id)
        {
            var product = productRepository.GetProduct(i => i.ID == id);

            if (product != null)
            {
                GetCard().DeleteToProduct(product);
            }
            return Redirect("Index");
        }

        public Card GetCard()
        {

            var card = (Card)Session["Card"];

            if (card == null)
            {
                card = new Card();
                Session["Card"] = card;
            }

            return card;
        }

        public PartialViewResult GetShop()
        {

            return PartialView(GetCard());
        }

        [Authorize]
        public ActionResult CheckOut()
        {

            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult CheckOut(ShippingDetails shippingDetails)
        {
            var card = GetCard();

            if (card.cardItems.Count == 0)
            {
                ModelState.AddModelError("", "Sepetinizde ürün yoktur");
            }

            else
            {
                if (ModelState.IsValid)
                {

                    SaveOrder(card, shippingDetails);
                    card.Clear();

                    return View("Completed");
                }
            }
            return View(shippingDetails);
        }

        private void SaveOrder(Card card, ShippingDetails shippingDetails)
        {
            var order = new Order();
            order.AddDate = DateTime.Now;
            order.OrderNumber = "A" + (new Random().Next(111111, 999999).ToString());
            order.Status = DAL.Entities.ORM.Entity.Enum.Status.Active;
            order.Total = card.Total();
            order.UserName = User.Identity.Name;
            order.PostaCode = shippingDetails.PostaCode;
            order.Adress = shippingDetails.Adress;
            order.City = shippingDetails.City;
            order.Region = shippingDetails.Region;
            order.OrderStatus = DAL.Entities.ORM.Entity.Enum.OrderStatus.Waiting;

            order.OrderItems = new List<OrderItem>();

            foreach (var item in card.cardItems)
            {
                var orderitem = new OrderItem();
                orderitem.Price = Convert.ToDecimal(item.Product.Price * item.Quantity);
                orderitem.Qantity = item.Quantity;
                orderitem.ProductID = item.Product.ID;

                order.OrderItems.Add(orderitem);
            }

            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}