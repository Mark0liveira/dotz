using Dotz.Data;
using Dotz.Exceptions;
using Dotz.Services;
using Dotz.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dotz.Controllers
{
    [Route("v1/rescue")]
    [Authorize]
    public class RescueController : Controller
    {
        private RescueService _rescueService;
        public RescueController()
        {
            _rescueService = new RescueService();
        }

        [HttpPost]
        public async Task<ActionResult> RescueProduct([FromServices] DataContext context, 
                                                    [FromBody]RescueProductValueObject body)
        {
            try
            {
                var rescue = await _rescueService.RescueProduct(body, context);
                return Ok("Resgate efetuado com suceso!");
            }
            catch (Exception e)
            {
                if (e is CustomException)
                {
                    return BadRequest(new { message = e.Message });
                }

                return BadRequest("Algo inesperado ocorreu!");
            }
        }
    }
}
