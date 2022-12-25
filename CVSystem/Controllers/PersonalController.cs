using Domain.IService;
using Domain.Models;
using Domain.Models.ServiceRespone;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalService _personalService;
        public PersonalController(IPersonalService personalService)
        {
            _personalService = personalService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            ServiceRespone<IEnumerable<PersonalRespone>> serviceRespone = await _personalService.GetAll();
            return Ok(serviceRespone);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Personal personal)
        {
            ServiceRespone<PersonalRespone> serviceRespone = await _personalService.Add(personal);
            return Ok(serviceRespone);
        }
    }
}
