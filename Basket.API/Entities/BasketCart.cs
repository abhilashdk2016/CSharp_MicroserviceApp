using System;
using System.Collections.Generic;

namespace Basket.API.Entities
{
    public class BasketCart
    {
        public BasketCart()
        {
            Items = new List<BasketCartItem>();
        }

        public BasketCart(string userName)
        {
            UserName = userName;
            Items = new List<BasketCartItem>();
        }

        public string UserName { get; set; }
        public List<BasketCartItem> Items { get; set; }

        // Calculate total price of cart
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Qauntity;
                }
                return totalPrice;
            }
        }
    }
}
