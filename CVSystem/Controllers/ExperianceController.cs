using Domain.IService;
using Domain.Models;
using Domain.Models.ServiceRespone;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperianceController : ControllerBase
    {
        private readonly IExperianceService _experianceService;
        public ExperianceController(IExperianceService experianceService)
        {
            _experianceService = experianceService; 
        }
        [HttpPost]
        public async Task<IActionResult> Add(Exp exp) { 
        ServiceRespone<ExpRespone> serviceRespone = await _experianceService.Add(exp);
        return Ok(serviceRespone);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ServiceRespone<IEnumerable<ExpRespone>> serviceRespone = await _experianceService.GetAll();
            return Ok(serviceRespone);
        }
    }
}
