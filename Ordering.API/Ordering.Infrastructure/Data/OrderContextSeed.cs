using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContect, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                orderContect.Database.Migrate();
                if(!orderContect.Orders.Any())
                {
                    orderContect.Orders.AddRange(GetPreConfiguredOrders());
                    await orderContect.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if(retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(orderContect, loggerFactory, retryForAvailability);
                }
            }
        }

        private static IEnumerable<Order> GetPreConfiguredOrders()
        {
            return new List<Order>
            {
                new Order { UserName = "swn", FirstName ="Abhilash", LastName = "D K", EmailAddress = "abhilashdk2014@outlook.com", AddressLine = "Tumkur", Country = "India" }
            };
        }
    }
}
