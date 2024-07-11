using Building.Blocks.Core.Exception.Types;

namespace Building.Blocks.Core.Exceptions.Domain;

public class InvalidNationalityException : BadRequestException
{
    public string Nationality { get; }

    public InvalidNationalityException(string nationality)
        : base($"Nationality: '{nationality}' is invalid.")
    {
        Nationality = nationality;
    }
}
