using System.Net;
using Building.Blocks.Core.Exception.Types;

namespace Building.Blocks.Core.Domain.Exceptions;

/// <summary>
/// Exception type for domain exceptions.
/// </summary>
public class DomainException : CustomException
{
    public DomainException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : base(message)
    {
        StatusCode = statusCode;
    }
}
