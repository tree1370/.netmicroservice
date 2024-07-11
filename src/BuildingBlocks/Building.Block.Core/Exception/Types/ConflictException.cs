using System.Net;

namespace Building.Blocks.Core.Exception.Types;

public class ConflictException : CustomException
{
    public ConflictException(string message)
        : base(message)
    {
        StatusCode = HttpStatusCode.Conflict;
    }
}
