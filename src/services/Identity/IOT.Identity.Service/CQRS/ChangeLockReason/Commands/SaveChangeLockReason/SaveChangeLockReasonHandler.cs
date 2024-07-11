using Building.Blocks.Application.Persistence;
using Building.Blocks.Core.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Identity.Service.CQRS.ChangeLockReason.Commands.SaveChangeLockReason
{
    public class SaveChangeLockReasonHandler : IRequestHandler<SaveChangeLockReasonRequest, SaveChangeLockReasonResponse>
    {
        private readonly IRepository<Domain.Core.ChangeLockReason> _changeLockReason;
        private readonly GetCurrentUser getCurrentUser;

        public SaveChangeLockReasonHandler(Building.Blocks.Application.Persistence.IRepository<Domain.Core.ChangeLockReason> changeLockReason,
            GetCurrentUser getCurrentUser)
        {
            this._changeLockReason = changeLockReason;
            this.getCurrentUser = getCurrentUser;
        }

        public async Task<SaveChangeLockReasonResponse> Handle(SaveChangeLockReasonRequest request, CancellationToken cancellationToken)
        {
            var currentUserId = getCurrentUser.GetUserId();
            var changeLockReason = Domain.Core.ChangeLockReason.Of(request.Message, request.IsLockType, DateTime.Now, currentUserId);

            await _changeLockReason.AddAsync(changeLockReason);

            var response = new SaveChangeLockReasonResponse()
            {
                Id = changeLockReason.Id
            };
            return response;
        }
    }
}
