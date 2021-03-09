using System;
using System.Threading.Tasks;
using Backend.Model;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private AlbumRepository Repository{get; set;}
        public AlbumController(AlbumRepository repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Repository.GetAll());
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetAlbum(Guid id)
        {
            var result = (await Repository.GetById(id));
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Album album)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await Repository.Save(album);
            return Created($"/{album.Id}", album);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Repository.GetById(id);
            await Repository.Remove(result);
            return NoContent();
        }
    }
}