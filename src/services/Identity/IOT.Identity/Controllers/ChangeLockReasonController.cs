using Building.Blocks.Core.Extensions;
using IOT.Identity.Domain.Core;
using IOT.Identity.Service.CQRS.ChangeLockReason.Commands.SaveChangeLockReason;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IOT.Identity.Controllers
{
    public class ChangeLockReasonController : BaseController
    {
        private readonly IMediator mediator;

        public ChangeLockReasonController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddChangeLockReason(SaveChangeLockReasonRequest saveChangeLockReasonRequest)
        {
            var result = await mediator.Send(saveChangeLockReasonRequest);
            return Ok(result);
        }
    }
}
