using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Catalog_Order.UI.Models.CardModel
{
    public class Card
    {
        private List<CardItem> _cardItems = new List<CardItem>();

        public List<CardItem> cardItems
        {

            get { return _cardItems; }
            
        }

        public void AddToProduct(Product product,int quantity)
        {

            var carditem = _cardItems.FirstOrDefault(i => i.Product.ID == product.ID);

            if (carditem == null)
            {
                _cardItems.Add(new CardItem() { Product = product, Quantity = quantity });
            }

            else
            {
                carditem.Quantity += quantity;
            }

        }

        public void DeleteToProduct(Product product)
        {

            _cardItems.RemoveAll(i => i.Product.ID == product.ID);
        }

        public decimal Total()
        {

            return _cardItems.Sum(i => Convert.ToDecimal(i.Product.Price * i.Quantity));
        }

        public void Clear()
        {

            _cardItems.Clear();
        }

    }
}