using Dotz.Data;
using Dotz.Models;
using Dotz.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dotz.Services
{
    public class RescueService
    {
        private UserService _userService;
        private ProductService _productService;
        private ExtractService _extractService;
        private OrderService _orderService;

        public RescueService()
        {
            _userService = new UserService();
            _productService = new ProductService();
            _extractService = new ExtractService();
            _orderService = new OrderService();
        }

        public async Task<RescueProductValueObject> RescueProduct(RescueProductValueObject rescue, 
                                                                    DataContext context)
        {
            var user = await _userService.GetUserById(rescue.UserId, context);

            var product = await _productService.GetProdut(rescue.ProductId, context);

            UpdateBalance(user, product, context);

            _orderService.CreateOrder(user, product, context);

            _extractService.CreateLogExtract(user, product, context);

            return rescue;
        }

        private void UpdateBalance(User user, Product product, DataContext context)
        {
            user.DotzCoin = (user.DotzCoin - product.DotzCoin);
            context.Entry(user).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
