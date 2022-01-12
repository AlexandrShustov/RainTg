using Application.Auth.Commands;
using Microsoft.AspNetCore.Mvc;
using RainTg.Controllers.Abstract;

namespace Web.Controllers
{
    [Route("api/auth")]
    public class AuthController : ApiControllerBase
    {
        [HttpGet]
        [Route("redirect/{chatId:long}")]
        public Task Redirect([FromQuery] string code, [FromRoute] long chatId)
        {
            return Mediator.Send(new RegisterClientCommand() { Code = code, ChatId = chatId });
        }
    }
}
