using Dotz.Data;
using Dotz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Dotz.Controllers
{
    [Route("v1/address")]
    [Authorize]
    public class DeliveryAddressController : Controller
    {
        [HttpGet]
        [Route("user/{id:int}")]
        public async Task<ActionResult<DeliveryAddress>> GetByUserId([FromServices] DataContext context, 
                                                                    int id)
        {
            if (await context.Users.FirstOrDefaultAsync(x => x.Id == id) is null)
                return BadRequest(new { message = "Usuário não encontrado" });

            var address = await context.DeliveryAddress
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == id && x.Enabled == true);

            return address;
        }

        [HttpPost]
        public async Task<ActionResult<DeliveryAddress>> Post([FromServices] DataContext context,
                                                                [FromBody] DeliveryAddress model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.DeliveryAddress.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o Endereço de Entrega" });

            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<DeliveryAddress>> Put([FromServices] DataContext context,
                                                            int id,
                                                            [FromBody] DeliveryAddress model)
        {
            if (id != model.Id)
                return NotFound(new { message = "Endereço de Entrega não encontrado" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar o Endereço de Entrega" });

            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<DeliveryAddress>> Delete([FromServices] DataContext context,
                                                                int id)
        {
            var address = await context.DeliveryAddress.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null)
                return NotFound(new { message = "Endereço de Entrega não encontrado" });

            try
            {
                address.Enabled = false;
                context.Entry(address).Property(x => x.Enabled).IsModified = true;
                await context.SaveChangesAsync();
                return address;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o Endereço de Entrega" });

            }
        }
    }
}
