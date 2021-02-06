using System;
using AutoMapper;
using Basket.API.Entities;
using EventBuRabbitMQ.Events;

namespace Basket.API.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
