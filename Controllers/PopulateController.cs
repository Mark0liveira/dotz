using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dotz.Data;
using Dotz.Models;

namespace Dotz.Controllers
{
    [Route("v1/populate")]
    public class PopulateController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<dynamic>> Populate([FromServices] DataContext context)
        {
            var user = new User { 
                Id = 1, Username = "Admin", 
                Email = "user@teste.com", 
                Password = "teste", 
                Role = "user" 
            };
            var company = new User { 
                Id = 2, 
                Username = "Manager", 
                Email = "user@teste.com",
                Password = "teste", 
                Role = "company" 
            };

            var category1 = new Category { Id = 2, Title = "Decoração" };

            var product1 = new Product
            {
                Id = 1,
                Category = category1,
                Title = "Lustre",
                DotzCoin = 500,
                DotzCoinReturned = 200,
                Description = "Lustre cromado"
            };

            var category2 = new Category { Id = 1, Title = "Informática" };

            var product2 = new Product { 
                Id = 2, 
                Category = category2, 
                Title = "Mouse", 
                DotzCoin = 300,
                DotzCoinReturned = 100,
                Description = "Mouse Gamer" 
            };

            context.Users.Add(user);
            context.Users.Add(company);
            context.Categories.Add(category1);
            context.Products.Add(product1);
            context.Categories.Add(category2);
            context.Products.Add(product2);

            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Informações populadas!"
            });
        }
    }
}