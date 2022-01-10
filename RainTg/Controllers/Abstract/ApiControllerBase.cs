using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RainTg.Controllers.Abstract
{
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        private IMediator? _mediator = null;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
