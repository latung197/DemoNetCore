using Coasia.WebApiRestful.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Coasia.WebApiRestful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthencationController : Controller
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] Accoutmodel accoutmodel)
        {
            if(accoutmodel == null)
            {
                return BadRequest("User not exists");
            }

            return View();
        }
    }
}
