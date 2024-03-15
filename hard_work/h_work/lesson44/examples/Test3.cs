
public class GermanVersionRouterTests
{
    [Fact]
    public async Task Route_NoBankSelectedAndPrefferedOffer_ShouldBeSourceVersion()
    {
        //Arrange
        var preOnboardingService = Mock.Resolve<IPreOnboardingService>();
        var router = new GermanVersionRouter(preOnboardingService);
        preOnboardingService.GetParamSourceGroup(Arg.Any<Guid>())
            .Returns(new PreOnboardingParamSourceGroup(new List<PreOnboardingParamSource>()));

        var rq = new RouteOnboardingVersionRequest(new BankOnboardingVersionData
        {
            BankCode = EBankCode.Solaris,
            Version = Versions.Solaris.Albatross
        })
        {
        };
        router.InitRq(rq);

        //Act
        var result = await router.Route();

        //Assert
        result.Value.Should().NotBeNull();
        result.Value.BankCode.Should().Be(EBankCode.Solaris);
        result.Value.Version.Should().Be(Versions.Solaris.Albatross);
    }

    [Fact]
    public async Task Route_BankSelectedWithSolaris_ShouldBeSourceVersion()
    {
        //Arrange
        var preOnboardingService = Mock.Resolve<IPreOnboardingService>();
        var router = new GermanVersionRouter(preOnboardingService);
        preOnboardingService.GetParamSourceGroup(Arg.Any<Guid>())
            .Returns(new PreOnboardingParamSourceGroup(new List<PreOnboardingParamSource>
            {
                new PreOnboardingParamSource
                {
                    CompanyId = Guid.NewGuid(),
                    Type = EPreOnboardingParamType.SelectedBank,
                    Value = JObject.FromObject(new SelectedBank
                    {
                        Code = EBankCode.Solaris
                    })
                }
            }));

        var rq = new RouteOnboardingVersionRequest(new BankOnboardingVersionData
        {
            BankCode = EBankCode.Solaris,
            Version = Versions.Solaris.Albatross
        })
        {
        };
        router.InitRq(rq);

        //Act
        var result = await router.Route();

        //Assert
        result.Value.Should().NotBeNull();
        result.Value.BankCode.Should().Be(EBankCode.Solaris);
        result.Value.Version.Should().Be(Versions.Solaris.Albatross);
    }
}