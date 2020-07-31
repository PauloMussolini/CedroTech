using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CedroTechApi.Models;
using CedroTechApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace CedroTechApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class DocumentController : ControllerBase
    {
        [HttpPost]
        [Produces("application/json")]
        [Authorize]
        [ProducesResponseType(401)]
        public IActionResult Create(User user)
        {
            try
            {
                if(String.IsNullOrEmpty(user.FullName))
                    return BadRequest("Full Name should be informed!");
                else if (String.IsNullOrEmpty(user.Email))
                    return BadRequest("Email should be informed!");
                else if (String.IsNullOrEmpty(user.CPF))
                    return BadRequest("CPF should be informed!");
                else if (String.IsNullOrEmpty(user.RG))
                    return BadRequest("RG should be informed!");


                IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
                string resultIp = "";
                if (remoteIpAddress != null)
                {
                    if (remoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    {
                        remoteIpAddress = System.Net.Dns.GetHostEntry(remoteIpAddress).AddressList
                                            .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                    }
                    resultIp = remoteIpAddress.ToString();
                }



                FileUtils.CreateFile(user, resultIp);

                return Ok("Document Created!" + remoteIpAddress);
            } catch (Exception e)
            {
                return BadRequest("Internal Error!");
            }

        }
    }
}
