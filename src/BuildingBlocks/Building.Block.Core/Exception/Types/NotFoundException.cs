using System.Net;

namespace Building.Blocks.Core.Exception.Types;

public class NotFoundException : CustomException
{
    public NotFoundException(string message)
        : base(message)
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}
