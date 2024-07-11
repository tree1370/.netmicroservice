using Ardalis.GuardClauses;

namespace Building.Blocks.SMS;

public interface ISmsSender
{
    Task SendAsync(SmsObject smsObject);
    Task SendVerificationCodeFastWithTemplateIdAsync(SmsObjectForVerificationWithTemplate forVerificationWithTemplate);
}

public class SmsObject
{
    public SmsObject(Int64 reciverNumber, string message)
    {
        ReciverNumber = Guard.Against.NegativeOrZero(reciverNumber, nameof(reciverNumber));
        Message = Guard.Against.NullOrEmpty(message, nameof(message));
    }


    public Int64 ReciverNumber { get; }

    public string Message { get; }
}

public class SmsObjectForVerificationWithTemplate
{
    public SmsObjectForVerificationWithTemplate(Int64 reciverNumber, string verificationCode, Int64 templateId, string userId)
    {
        ReciverNumber = Guard.Against.NegativeOrZero(reciverNumber, nameof(reciverNumber));
        VerificationCode = Guard.Against.NullOrEmpty(verificationCode, nameof(verificationCode));
        TemplateId = Guard.Against.NegativeOrZero(templateId, nameof(templateId));
        UserId = Guard.Against.NullOrEmpty(userId, nameof(userId));
    }


    public Int64 ReciverNumber { get; }
    public Int64 TemplateId { get; }
    public string VerificationCode { get; }
    public string UserId { get; }
    
}