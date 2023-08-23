namespace h_work.lesson18.part3.example2;

//Before
public interface ITranslatorService
{
    Task<string> Translate(string text, string sourceLang, string targetLang);
    Task<string> TranslateToEnglish(string text, string sourceLang = null);
}



//After
public record TranslatedString(string Value, string OriginLanguage);
public record TranslateRequest(string Text, string SourceLanguage, string TargetLanguage);
public interface ITranslatorServiceV2
{
    Task<TranslatedString> Translate(TranslateRequest request);
}

public record TranslateToEnglishRequest(string Text, string SourceLanguage) : TranslateRequest(Text, SourceLanguage, "EN");
public static class Extensions
{
    public static Task<TranslatedString> TranslateToEnglish(this ITranslatorServiceV2 service, TranslateToEnglishRequest request)
    {
        return service.Translate(request);
    }
}
