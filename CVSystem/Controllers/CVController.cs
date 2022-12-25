using Domain.IService;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly ICVService _CVService;
        public CVController(ICVService CVService)
        {
            _CVService = CVService;
        }
        [HttpPost]
        public IActionResult Add([FromBody]CVMod cv) {
            
            return Ok(_CVService.Add(cv));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _CVService.GetAll());
        }
    }
}
