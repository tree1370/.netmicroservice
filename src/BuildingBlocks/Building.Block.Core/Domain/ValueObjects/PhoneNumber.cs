using Ardalis.GuardClauses;
using Building.Blocks.Core.Domain.Exceptions;
using Building.Blocks.Core.Exception;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace Building.Blocks.Core.Domain.ValueObjects;

// https://learn.microsoft.com/en-us/ef/core/modeling/constructors
public record PhoneNumber
{
    public string CountryCode { get; private set; } = default!;
    public string PhoneNumberWithOutCountryCode { get; private set; } = default!;
    // EF
    public string FullPhoneNumber => CountryCode + PhoneNumberWithOutCountryCode;

    private PhoneNumber(string countryCode,string phoneNumberWithOutCountryCode)
    {
        CountryCode = countryCode;
        PhoneNumberWithOutCountryCode = phoneNumberWithOutCountryCode;
    }

    // Note: in entities with none default constructor, for setting constructor parameter, we need a private set property
    // when we didn't define this property in fluent configuration mapping (if so we can remove private set) , because for getting mapping list of properties to set
    // in the constructor it should not be read only without set (for bypassing calculate fields)- https://learn.microsoft.com/en-us/ef/core/modeling/constructors#read-only-properties

    public static PhoneNumber Of(string countryCode,string phoneNumberWithOutCountryCode)
    {
        // validations should be placed here instead of constructor
        Guard.Against.InvalidPhoneNumber(countryCode, phoneNumberWithOutCountryCode, new DomainException($"Phone number with country code : '{countryCode}' and number '{phoneNumberWithOutCountryCode}' is invalid."));
        return new PhoneNumber(countryCode,phoneNumberWithOutCountryCode);
    }

    public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.FullPhoneNumber;
}
