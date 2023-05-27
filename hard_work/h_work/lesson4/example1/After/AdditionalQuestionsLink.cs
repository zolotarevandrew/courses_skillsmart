namespace h_work.lesson4.example1.After;

public class AdditionalQuestionsLink
{
    private readonly IGlobalInfo _globalInfo;
    private readonly AdditionalQuestionsConfig _config;

    public AdditionalQuestionsLink(IGlobalInfo globalInfo, AdditionalQuestionsConfig config)
    {
        _globalInfo = globalInfo;
        _config = config;
    }

    public string Get(string lang)
    {
        return _globalInfo.Domain.TrimEnd(new[] { '/' }) + $"/{(lang).ToLower()}{_config.AdditionalQuestionsUrl}";
    }
}