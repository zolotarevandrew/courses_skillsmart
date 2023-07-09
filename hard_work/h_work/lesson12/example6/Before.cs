namespace h_work.lesson12.example6;

public interface IGlobalInfo
{
    string Domain { get; }
}
public class Before
{
    private readonly IGlobalInfo _globalInfo;

    public Before(IGlobalInfo globalInfo)
    {
        _globalInfo = globalInfo;
    }
    public string LivenessCheckUrl(Guid sid, Guid companyId)
    {
        var url = new Uri(new Uri(_globalInfo.Domain), $"onboarding/personal-liveness-check/{sid}?company={companyId}");
        return url.ToString();
    }
}