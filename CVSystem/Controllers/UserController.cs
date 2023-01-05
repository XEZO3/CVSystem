using Domain.IService;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto register) {

            return Ok(await _userService.Register(register));
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {

            return Ok(await _userService.Login(login));
        }
    }
}
