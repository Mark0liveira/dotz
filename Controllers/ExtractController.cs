using Dotz.Data;
using Dotz.Services;
using Dotz.Utils.Generate;
using Dotz.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dotz.Controllers
{
    [Route("v1/extract")]
    [Authorize]
    public class ExtractController : Controller
    {
        private ExtractService _extractService;
        public ExtractController()
        {
            _extractService = new ExtractService();
        }

        [HttpGet]
        [Route("user/{id:int}")]
        public ActionResult<ExtractAndBalanceValueObject> GetByUserId(int id,
                                                [FromServices] DataContext context)
        {
            try
            {
                var valueObject = _extractService.GetExtractByUserId(id, context);
                return Ok(valueObject);
            }
            catch (Exception e)
            {
                var handle = new GenerateException();
                return handle.build(e);
            }
        }
    }
}
