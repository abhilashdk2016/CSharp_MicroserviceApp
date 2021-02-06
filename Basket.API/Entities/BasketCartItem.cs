﻿using System;
namespace Basket.API.Entities
{
    public class BasketCartItem
    {
        public BasketCartItem()
        {
        }

        public int Qauntity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
