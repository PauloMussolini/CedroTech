using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CedroTechApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersionController : ControllerBase
    {

        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            var version = new
            {
                Name = "Cedro Tech Api",
                Version = "1.0",
                Author = "Paulo de Tarso F Mussolini"
            };

            return Ok(version);
        }
    }
}
