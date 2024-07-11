using System.Net;

namespace Building.Blocks.Core.Exception.Types;

public class ForbiddenException : IdentityException
{
    public ForbiddenException(string message)
        : base(message, statusCode: HttpStatusCode.Forbidden) { }
}
