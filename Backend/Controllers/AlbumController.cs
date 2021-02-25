using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        public AlbumController()
        {

        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(new {
                Id = Guid.NewGuid().ToString(),
                Title = "Album legal",
                Descricao = "Lorem ipsum Lorem ipsum"
            });
        }
    }
}