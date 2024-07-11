using Building.Blocks.Core.Exception.Types;

namespace Building.Blocks.Core.Exceptions.Domain;

public class UnsupportedNationalityException : BadRequestException
{
    public string Nationality { get; }

    public UnsupportedNationalityException(string nationality)
        : base($"Nationality: '{nationality}' is unsupported.")
    {
        Nationality = nationality;
    }
}
