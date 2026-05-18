using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Ordering Database: {typeof(OrderContext).Name} seeded");
            }
        }

        private static IEnumerable<Order> GetOrders()
        {
            return new List<Order>
            {
                new()
                {
                    UserName = "xuanphong",
                    FirstName = "Xuan Phong",
                    LastName = "Tran",
                    EmailAddress = "xuanphong@gmail.com",
                    AddressLine = "Ly Thuong Kiet Street",
                    State = "HCM City",
                    Country = "Viet Name",
                    ZipCode = "10000",

                    CardName = "Visa",
                    CardNumber = "4111111111111111",
                    CreatedBy = "Xuan Phong",
                    Expiration = "12/29",
                    Cvv = "123",
                    PaymentMethod = 1,
                    LastModifiedBy = "Xuan Phong",
                    LastModifiedDate = DateTime.UtcNow
                }
            };
        }
    }
}