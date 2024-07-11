using System.Net;
using Building.Blocks.Core.Exception.Types;

namespace IOT.Identity.Service.Exceptions.Application;

public class CustomerNotFoundException : AppException
{
    public CustomerNotFoundException(string message)
        : base(message, HttpStatusCode.NotFound) { }

    public CustomerNotFoundException(long id)
        : base($"Customer with id '{id}' not found.", HttpStatusCode.NotFound) { }

    public CustomerNotFoundException(Guid id)
        : base($"Customer with id '{id}' not found.", HttpStatusCode.NotFound) { }
}
