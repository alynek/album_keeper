using Backend.Model;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private AlbumRepository AlbumRepository{get; set;}

        public MusicController(AlbumRepository repository)
        {
            AlbumRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var music = await AlbumRepository.GetMusicFromAlbum(id);
            return Ok(music);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var music = await AlbumRepository.GetMusic(id);
            return Ok(music);
        }


        [HttpPost("{albumId}")]
        public async Task<IActionResult> Post(Guid albumId, Music model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var album = await AlbumRepository.GetById(albumId);
            album.Musics.Add(model);
            await AlbumRepository.Update(album);
            return Ok();
        }
    }
}