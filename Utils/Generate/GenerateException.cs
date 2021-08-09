using Dotz.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dotz.Utils.Generate
{
    public class GenerateException : ControllerBase
    {
        public ActionResult build(Exception e)
        {
            if (e is CustomException)
            {
                return BadRequest(new { message = e.Message });
            }

            return BadRequest("Algo inesperado ocorreu!");
        }
    }
}
