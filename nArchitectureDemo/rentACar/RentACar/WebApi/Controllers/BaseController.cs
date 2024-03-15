using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BaseController:ControllerBase

    //eğer daha önce mediator enjekte edilmişse onu döndür edilmemişse ise git IoC ortamına bak IMediator karşılığını bana ver
    {
        private IMediator? _mediator;

        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
