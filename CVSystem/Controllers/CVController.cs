using Domain.IService;
using Domain.Models;
using Domain.Models.filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<IActionResult> GetAll([FromQuery]CvFilter filter = null)
        {
            return Ok(await _CVService.GetAll(x=> (x.personal.FullName.Contains(filter.FullName) || filter.FullName == null)));
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id) {
            return Ok(_CVService.GetById(Id));
        }
        [HttpDelete]
        public IActionResult Delete([FromBody]CVMod cv) {
            return Ok(_CVService.Delete(cv));
        }
    }
}
