using Dotz.Data;
using Dotz.Enums;
using Dotz.Exceptions;
using Dotz.Models;
using Dotz.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Services
{
    public class OrderService
    {
        public async Task<List<OrderValueObject>> GetOrderByUserId(DataContext context,
                                                                    int id)
        {

            var user = await context.Users
                .FirstOrDefaultAsync(x => x.Id == id && x.Enabled == true);

            if (user is null)
                throw new CustomException("Usuário não encontrado");

            var orders = await context.Order
                .Where(x => x.UserId == user.Id)
                .ToListAsync();

            var valueObjects = new List<OrderValueObject>();
            foreach (var order in orders)
            {
                var valueObject = BuildOrderOnValueObject(order);

                AddProductsOnValueObject(valueObject, order.Products);

                valueObjects.Add(valueObject);
            }

            return valueObjects;
        }

        public OrderValueObject BuildOrderOnValueObject(Order order)
        {
            return new OrderValueObject(
                        order.Code,
                        order.DeliveryStatus,
                        order.CreatedDate,
                        order.LastUpdateDate,
                        order.Total);
        }

        public void AddProductsOnValueObject(OrderValueObject valueObject, List<Product> products)
        {
            foreach (var product in products)
            {
                valueObject.AddProduct(product);
            }
        }

        public async void CreateOrder(User user, Product product, DataContext context)
        {
            var order = new Order()
            {
                Code = new Guid(),
                CreatedDate = new DateTime(),
                LastUpdateDate = new DateTime(),
                DeliveryStatus = DeliveryStatus.SENT,
                Total = product.DotzCoin,
                UserId = user.Id
            };

            context.Order.Add(order);
            context.SaveChanges();
        }
    }
}
