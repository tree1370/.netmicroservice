namespace Building.Blocks.Core.Exception.Types;

public class InvalidPhoneNumberException : BadRequestException
{
    public string CountryCode { get; }
    public string PhoneNumberWithOutCountryCode { get; }

    public InvalidPhoneNumberException(string countryCode,string phoneNumberWithOutCountryCode)
        : base($"Contry code: '{countryCode}' and PhoneNumber : '{phoneNumberWithOutCountryCode}' is invalid.")
    {
        CountryCode = countryCode;
        PhoneNumberWithOutCountryCode = phoneNumberWithOutCountryCode;
    }
}
