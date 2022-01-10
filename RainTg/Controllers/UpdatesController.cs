using Microsoft.AspNetCore.Mvc;
using RainTg.Controllers.Abstract;

namespace RainTg.Controllers
{
    public class UpdatesController : ApiControllerBase
    {
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
