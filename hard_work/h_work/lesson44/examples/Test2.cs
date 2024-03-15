public class IPCheckResultAnalyzerTests
{
    private readonly IFeatureToggleHelper _featureHelper;
    private readonly IPCheckResultAnalyzer _analyzer;

    public IPCheckResultAnalyzerTests()
    {
        _featureHelper = Mock.Resolve<IFeatureToggleHelper>();
        _featureHelper.IsAvailableAsync(EFeatures.DeclineByIpCheckForUnregisteredFreelancer, Arg.Any<string>()).Returns(true);
        _analyzer = new IPCheckResultAnalyzer(_featureHelper);
    }

    [Fact]
    public async void EmptyChecks_NeedDecline_ShouldReturnFalse()
    {
        // Arrange
        var checks = new HashSet<EIpCheckResult>();
        // Act
        var (shouldDecline, reason) = await _analyzer.NeedDecline(checks);
        // Assert

        shouldDecline.Should().BeFalse();
        reason.Should().BeEmpty();
    }

    [Theory]
    [MemberData(nameof(RiskyAsnShouldBeTrue))]
    public async void RiskyAsn_NeedDecline_ShouldReturnTrue(EIpCheckResult[] input)
    {
        // Arrange
        var checks = new HashSet<EIpCheckResult>(input);
        // Act
        var (shouldDecline, reason) = await _analyzer.NeedDecline(checks);
        // Assert

        shouldDecline.Should().BeTrue();
        reason.Should().Be("IPRiskyASN");
    }