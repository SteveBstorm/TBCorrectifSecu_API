using CorrectifSecu_API.Models;
using CorrectifSecu_API.Services;
using CorrectifSecu_API.Tools;
using CorrectifSecu_BLL.LocalServices;
using CorrectifSecu_DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using API = CorrectifSecu_API.Models;
using DAL = CorrectifSecu_DAL.Models;

namespace CorrectifSecu_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TokenManager _tokenManager;
        private readonly IAppUserRepository _userRepo;
        private readonly LocalUserService _userService;

        public UserController(TokenManager tokenManager, IAppUserRepository userRepo, LocalUserService userService)
        {
            _tokenManager = tokenManager;
            _userRepo = userRepo;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(FormLogin form)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                API.AppUser currentUser = _userRepo.Login(form.Email, form.Password).ToApi();

                currentUser.Token = _tokenManager.GenerateJWT(currentUser);

                return Ok(currentUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Register(FormRegister form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _userService.RegisterUser(form.ToLocal());

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.GetCompleteUser(id));
        }
    }
}
