using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CedroTechApi.Models;
using CedroTechApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CedroTechApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Produces("application/json")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                if (String.IsNullOrEmpty(user.Email)){
                    return BadRequest("Email Invalid!");
                } else if (String.IsNullOrEmpty(user.Password))
                {
                    return BadRequest("Password Invalid!");
                }
                if (user.Email == "paulo_mussolini@yahoo.com.br" && user.Password == "Secret")
                    return Ok(TokenUtils.CreateToken()); // retorna Token (JWT)
                else
                    return BadRequest("Email or Password Invalid!");
            }
            catch (Exception e)
            {
                return BadRequest("Internal Error");
            }

        }
    }
}
