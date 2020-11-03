using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager jwt;

        public TokenController(JwtManager jwt)
        {
            this.jwt = jwt;
        }

        //POST
        [HttpPost]
        public IActionResult Post([FromBody] LoginUserDto actor)
        {
            try
            {
                var token = jwt.MakeToken(actor);
                return Ok(new { token });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }
    }
}