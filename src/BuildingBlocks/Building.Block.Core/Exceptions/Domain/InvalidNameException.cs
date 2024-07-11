using Building.Blocks.Core.Exception.Types;

namespace Building.Blocks.Core.Exceptions.Domain;

public class InvalidNameException : BadRequestException
{
    public string Name { get; }

    public InvalidNameException(string name)
        : base($"Name: '{name}' is invalid.")
    {
        Name = name;
    }
}
