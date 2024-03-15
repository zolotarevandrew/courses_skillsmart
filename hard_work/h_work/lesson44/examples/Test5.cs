

public class AdditionalQuestionsAobBannerServiceTests
{
    private readonly IAdditionalQuestionsAobBannerService _sut;
    private readonly IAOBBannerService _bannerService;
    private readonly IPublisher _publisher;
    
    public AdditionalQuestionsAobBannerServiceTests()
    {
        _sut = Mock.Resolve<IAdditionalQuestionsAobBannerService>();
        _bannerService = Mock.Resolve<IAOBBannerService>();
        _publisher = Mock.Resolve<IPublisher>();
    }

    [Fact]
    public async Task SetHasUnansweredQuestions_AllOk_ShouldUpsert()
    {
        var companyId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        await _sut.SetHasUnansweredQuestions(companyId, userId);

        await _bannerService.Received(1)
            .Upsert(Arg.Is<UpsertBannerEntity>(x =>
                x.CompanyId == companyId
                && x.BannerType == EAobBannerType.AdditionalQuestions
                && x.NewStatus == EAobBannerStatus.Active
                && x.UserId == userId));
    }

    [Fact]
    public async Task SetHasNoUnansweredQuestions_NoAdditionalQuestionsBanner_ShouldSkip()
    {
        var companyId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _bannerService.GetActiveBanners(Arg.Any<Guid>(), Arg.Any<Guid>())
            .Returns(Task.FromResult(new List<AobBannerInStorage>
            {
                new () { BannerType = EAobBannerType.ReviewDetails },
                new () { BannerType = EAobBannerType.FinomNotStarted },
                new () { BannerType = EAobBannerType.WaitingTaxInfoCheck }
            }));

        await _sut.SetHasNoUnansweredQuestions(companyId, userId);

        await _bannerService.Received(0).Upsert(Arg.Any<UpsertBannerEntity>());
        await _publisher.Received(0).PublishAsync(Arg.Any<DelayCometPushMessage>());
    }

    [Fact]
    public async Task SetHasNoUnansweredQuestions_ActiveBannerExists_ShouldChangeStatusAndPublishNotification()
    {
        var companyId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _bannerService.GetActiveBanners(Arg.Any<Guid>(), Arg.Any<Guid>())
            .Returns(Task.FromResult(new List<AobBannerInStorage>
            {
                new () { BannerType = EAobBannerType.AdditionalQuestions },
            }));

        await _sut.SetHasNoUnansweredQuestions(companyId, userId);

        await _bannerService.Received(1)
            .Upsert(Arg.Is<UpsertBannerEntity>(x =>
                x.CompanyId == companyId
                && x.BannerType == EAobBannerType.AdditionalQuestions
                && x.NewStatus == EAobBannerStatus.Inactive
                && x.UserId == userId));

        await _publisher.Received(1)
            .PublishAsync(Arg.Is<DelayCometPushMessage>(x =>
                x.CompanyId == companyId
                && x.NotificationType == "BankOnboardingBannerStatusChanged"
                && x.PushContext == CometPush.Context
                && x.TimeoutMs == 5_000
                && x.UserIds.Any(id => id == userId.ToString())
                && x.Key == companyId.ToString()
                && x.Data != null));
    }



}