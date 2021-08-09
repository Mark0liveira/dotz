using Dotz.Data;
using Dotz.Exceptions;
using Dotz.Models;
using Dotz.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Services
{
    public class ProductService
    {
        public async Task<List<ProductValueObject>> GetProductsAvailableByUser(int id, DataContext context)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(x => x.Id == id && x.Enabled == true);

            if (user is null)
                throw new CustomException("Usuário não encontrado");

            var products = await context.Products
                .Where(x => x.DotzCoin < user.DotzCoin)
                .ToListAsync();

            var valueObject = new List<ProductValueObject>();
            foreach (var product in products)
            {
                valueObject.Add(new ProductValueObject(
                    product.Id,
                    product.Title,
                    new DotzCoin(product.DotzCoin),
                    product.CategoryId));
            }

            return valueObject;
        }

        public async Task<Product> GetProdut(int id, DataContext context)
        {
            var user = await context.Products
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
                throw new CustomException("Produto não encontrado");

            return user;
        }
    }
}
