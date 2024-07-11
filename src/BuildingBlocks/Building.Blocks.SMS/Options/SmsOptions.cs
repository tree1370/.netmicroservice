namespace Building.Blocks.SMS.Options;

public class SmsOptions
{
    public SmsIrOption? SmsIrOption { get; set; }
    public SmsIrUltraFastVerifticationOption? SmsIrUltraFastVerifticationOption { get; set; }
    public SendGridOptions? SendGridOptions { get; set; }
}
public class SmsIrOption
{
    public string UserApikey { get; set; }
    public string SecretKey { get; set; }
}


public class SmsIrUltraFastVerifticationOption
{
    public int TemplateId { get; set; }
}

public class SendGridOptions
{
    public string? ApiKey { get; set; }
}