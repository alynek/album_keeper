using System;
using System.Text;
using System.Threading.Tasks;
using Backend.Model;
using Backend.Repository;
using Backend.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class UserController : ControllerBase
    {     
        private UserRepository Repository{get; set;} 
        private AlbumRepository AlbumRepository{get; set;}
        public UserController(UserRepository repository, AlbumRepository albumRepository)
        {
            Repository = repository;
            AlbumRepository = albumRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User();
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(model.Password));
            user.Photo = $"https://robohash.org/{Guid.NewGuid()}.png?bgset=any";

            await Repository.Save(user);
            return Created($"{user.Id}", user);
        }

        [HttpGet("{id}/favorite-music")]
        public async Task<IActionResult> GetUserFavoriteMusic(Guid id)
        {
            return Ok(await Repository.GetFavoriteMusics(id));
        }

        [HttpPost("{id}/favorite-music/{musicId}")]
        public async Task<IActionResult> SaveUserFavoriteMusic(Guid id, Guid musicId)
        {
            var music = await AlbumRepository.GetMusic(musicId);
            var user = await Repository.GetById(id);

            user.AddFavoriteMusic(music);
            await Repository.Update(user);
            return Ok(user);
        }

        [HttpDelete("{id}/favorite-music/{musidId}")]
        public async Task<IActionResult> RemoveUserFavoriteMusic(Guid id, Guid musicId)
        {
            var music = await AlbumRepository.GetMusic(musicId);
            var user = await Repository.GetById(id);

            user.RemoveFavoriteMusic(music);
            await Repository.Update(user);
            return Ok(user);
        }
    }
}