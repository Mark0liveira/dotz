using Dotz.Data;
using Dotz.Exceptions;
using Dotz.Services;
using Dotz.Utils.Generate;
using Dotz.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dotz.Controllers
{
    [Route("v1/order")]
    [Authorize]
    public class OrderController : Controller
    {
        private OrderService _orderService;
        public OrderController()
        {
            _orderService = new OrderService();
        }

        [HttpGet]
        [Route("user/{id:int}")]
        public async Task<ActionResult<OrderValueObject>> GetOrderByUserId([FromServices] DataContext context,
                                                                            int id)
        {
            try
            {
                var orderValueObject = await _orderService
                    .GetOrderByUserId(context, id);

                return Ok(orderValueObject);
            }
            catch (Exception e)
            {
                var handle = new GenerateException();
                return handle.build(e);
            }
        }
    }
}
