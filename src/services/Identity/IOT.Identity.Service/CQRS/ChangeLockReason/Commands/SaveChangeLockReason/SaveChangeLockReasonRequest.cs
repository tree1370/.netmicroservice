using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Identity.Service.CQRS.ChangeLockReason.Commands.SaveChangeLockReason
{
    public class SaveChangeLockReasonRequest : IRequest<SaveChangeLockReasonResponse>
    {
        public string Message { get; set; }
        public bool IsLockType { get; private set; }
    }
}
