using Microsoft.AspNetCore.Mvc;

namespace RainTg.Controllers.Abstract
{
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
