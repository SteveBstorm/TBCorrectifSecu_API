using CorrectifSecu_API.Models;
using CorrectifSecu_API.Tools;
using CorrectifSecu_DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorrectifSecu_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerRepository _repo;

        public BeerController(IBeerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll().Select(x => x.ToApi()));
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            return Ok(_repo.GetById(id).ToApi());
        }

        [HttpPost]
        public IActionResult Create(FormCreateBeer form)
        {
            if(!ModelState.IsValid) return BadRequest();

            _repo.Create(form.ToDal());
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(FormUpdateBeer form)
        {
            if (!ModelState.IsValid) return BadRequest();
            _repo.Update(form.ToDal());
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }

        [HttpGet("favorite/{id}")]
        public IActionResult Favorite(int id)
        {
            return Ok(_repo.GetFavoriteByUserId(id).Select(x => x.ToApi()));
        }

        [HttpPost("favorite")]
        public IActionResult AddFav(AddFavorite info)
        {
            _repo.AddFavorite(info.UserId, info.BeerId);
            return Ok();
        }
    }

}
