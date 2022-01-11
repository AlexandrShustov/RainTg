using Application.Updates.Notifications;
using Microsoft.AspNetCore.Mvc;
using RainTg.Controllers.Abstract;
using Telegram.Bot.Types;

namespace RainTg.Controllers
{
    public class UpdateController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] Update update)
        {
            await Mediator.Publish(new UpdateReceivedNotification() { Update = update });
            return Ok();
        }

        [HttpGet]
        [Route("api/update/ping")]
        public IActionResult Ping()
        {
            return Ok("It works");
        }
    }
}
