using System.Net;

namespace Building.Blocks.Core.Exception.Types;

public class UnAuthorizedException : IdentityException
{
    public UnAuthorizedException(string message)
        : base(message, HttpStatusCode.Unauthorized) { }
}
