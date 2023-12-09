using h_work.lesson9.example1;

public interface IFinomOnboardingNotificationScope
{
    IFinomOnboardingSmsNotificationService SmsService { get; }
    IFinomOnboardingEmailNotificationService EmailService { get; }
}

public interface IFinomOnboardingPusher
{
}

public interface IFinomOnboardingEmailNotificationService
{
    Task Send(Email email, SpecificEmailModel model);
}

public class SpecificEmailModel
{
    
}

public interface IFinomOnboardingSmsNotificationService
{
    Task Send(MobilePhone phone, SpecificSmsModel model);
}

public class SpecificSmsModel
{
    
}

public class UserNotificationSettings
{
    public string Language { get; init; }
    public string FullName { get; init; }
    public MobilePhone Phone { get; init; }
    public Email Email { get; init; }
}

public class Email
{
}

public class MobilePhone
{
}

public class CompanyNotificationSettings
{
    public string Name { get; init; }
}

public interface IFinomOnboardingNotificationScopeFactory
{
    IFinomOnboardingNotificationScope Get();
    Task<UserNotificationSettings> GetUserSettings(Guid userId);
    Task<CompanyNotificationSettings> GetCompanySettings(Guid companyId);
}