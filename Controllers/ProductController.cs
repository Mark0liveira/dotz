using Dotz.Data;
using Dotz.Exceptions;
using Dotz.Services;
using Dotz.Utils.Generate;
using Dotz.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Controllers
{
    [Route("v1/product")]
    [Authorize]
    public class ProductController : Controller
    {
        private ProductService _productService;
        public ProductController()
        {
            _productService = new ProductService();
        }

        [HttpGet]
        [Route("user/{id:int}")]
        public async Task<ActionResult<List<ProductValueObject>>> GetProductsByUser([FromServices] DataContext context,
                                                                                    int id)
        {
            try
            {
                var valueObjects = await _productService.GetProductsAvailableByUser(id, context);
                return Ok(valueObjects);
            }
            catch (Exception e)
            {
                var handle = new GenerateException();
                return handle.build(e);
            }
        }
    }
}
