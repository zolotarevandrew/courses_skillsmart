namespace h_work.lesson29.example3;

public interface IUserInfoGetter
{
    Task<UserInfo> Get(Guid userId); 
}

public interface ICompanyInfoGetter
{
    Task<CompanyInfo> Get(Guid companyId);
}

public class CompanyInfo
{
    public string Name { get; set; }
}

public class UserInfo
{
    public string PhoneCode { get; set; }
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    public string Language { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Before
{
    private readonly IUserInfoGetter _userInfoGetter;

    public Before(IUserInfoGetter userInfoGetter)
    {
        _userInfoGetter = userInfoGetter;
    }
    
    public async Task Send()
    {
        /* Пример как использовалось ДО
         var userId = Guid.NewGuid();
        var user = await _userInfoGetter.Get(userId, CancellationToken.None);
        var title = await _localizationService
            .GetTermOrEnOrNullExt("backend.onboarding.additionalquestions.mobilepush.title", user.Language);
        var text = await _localizationService
            .GetTermOrEnOrNullExt("backend.onboarding.additionalquestions.mobilepush.text", user.Language);
        await _pushService.MobilePush(new MobilePushContract()
        {
            UserId = message.UserId,
            CompanyId = message.CompanyId,
            Title = title,
            Text = text,
            IsUrgent = true,
            Ttl = TimeSpan.FromMinutes(1),
            Payload = new MobilePushContractPayload()
            {
                Type = "AdditionalQuestionsNotification",
                Data = new
                {
                    companyId = message.CompanyId
                }
            },
        });*/
    }
}