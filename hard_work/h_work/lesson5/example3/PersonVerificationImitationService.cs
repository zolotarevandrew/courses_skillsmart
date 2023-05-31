using h_work.lesson3.before;

namespace h_work.lesson5.example3;

/// <summary>
/// постоянно проходить верификацию руками - достаточно проблемый процесс, который требовал до 5-10 минут ручного времени
/// потому мы имеем реальный механизм автоматизации прохождения верификации - благо провайдер умеет это делать по АПИ
/// важно было имитировать следующие кейсы
/// - по несовпадению имени или других полей
/// - успешность верификации
/// - ошибочную верификацию
/// - фродстерское поведение
/// - повторное прохождение
/// </summary>
public class PersonVerificationImitationService
{
    private readonly IIdCheckOuterService _idCheckOuterService;
    private const string DefaultCountry = "CYP";

    public PersonVerificationImitationService(IIdCheckOuterService idCheckOuterService)
    {
        _idCheckOuterService = idCheckOuterService;
    }

    public async Task<VerificationResult> Imitate(
        PersonVerification verification,
        ImmitatePersonVerificationRequest request)
    {

        ImitateVerificationRequestContract sumSubContract = new()
        {
            PersonId = request.PersonId,
            CustomerPersonalInfo = new(),
        };

        sumSubContract.CustomerPersonalInfo.FirstName =
            NullIfEmptyStringOrDefault(request.Info?.FirstName, verification.FirstName);
        sumSubContract.CustomerPersonalInfo.LastName =
            NullIfEmptyStringOrDefault(request.Info?.LastName, verification.LastName);
        sumSubContract.CustomerPersonalInfo.Nationality =
            NullIfEmptyStringOrDefault(request.Info?.Nationality, DefaultCountry);
        sumSubContract.CustomerPersonalInfo.CountryOfBirth =
            NullIfEmptyStringOrDefault(request.Info?.CountryOfBirth, DefaultCountry);
        sumSubContract.CustomerPersonalInfo.PlaceOfBirth =
            NullIfEmptyStringOrDefault(request.Info?.PlaceOfBirth, DefaultCountry);

        sumSubContract.CustomerPersonalInfo.DateOfBirth = NullIfEmptyStringOrDefault(request.Info?.DateOfBirth);
        sumSubContract.LevelName = verification.Level;
        sumSubContract.CustomerPersonalInfo.Docs = GetDocs(request.Info);

        var response =  await _idCheckOuterService.ImitateVerification(sumSubContract);

        return new VerificationResult
        {
            Error = response.Error,
        };
    }
    
    public async Task<VerificationResult> Apply(PersonVerification verification,
        ApplyPersonVerificationRequest request)
    {
        var res = await _idCheckOuterService.MarkCompleted(request);

        return new VerificationResult
        {
            Error = res.Error,
        };
    }

    private static string NullIfEmptyStringOrDefault(string value, string def = null)
    {
        return string.IsNullOrWhiteSpace(value) ||
               value.Trim().Equals("string", StringComparison.OrdinalIgnoreCase)
            ? def
            : value;
    }

    private static PersonalDocumentInfo[] GetDocs(ImitatePersonalInfo contractInfo)
    {
        var fakeValidUntil = DateTime.UtcNow.AddMonths(12).ToString("yyyy-MM-dd");
        var fakeDocNumber = Guid.NewGuid().ToString();

        return new PersonalDocumentInfo[]
        {
            new()
            {
                Type = "PASSPORT",
                SubType = "FRONT_SIDE",
                ValidUntil = NullIfEmptyStringOrDefault(contractInfo?.DocValidUntil, fakeValidUntil),
                Number = NullIfEmptyStringOrDefault(contractInfo?.DocNumber, fakeDocNumber),
                Country = NullIfEmptyStringOrDefault(contractInfo?.DocCountry, DefaultCountry),
            },
            new()
            {
                Type = "PASSPORT",
                SubType = "BACK_SIDE",
                ValidUntil = NullIfEmptyStringOrDefault(contractInfo?.DocValidUntil, fakeValidUntil),
                Number = NullIfEmptyStringOrDefault(contractInfo?.DocNumber, fakeDocNumber),
                Country = NullIfEmptyStringOrDefault(contractInfo?.DocCountry, DefaultCountry),
            },
            new()
            {
                Type = "SELFIE",
                Country = DefaultCountry,
            }
        };
    }
}

public class ApplyPersonVerificationRequest
{
    public EVerificationType Type { get; set; }
}

public enum EVerificationType
{
    Reject = 1,
    Approved = 2,
    Repeat = 3,
    Fraud = 4,
}

public class ImitateVerificationRequestContract
{
    public Guid PersonId { get; set; }
    public PersonalInfoContract CustomerPersonalInfo { get; set; }
    public string LevelName { get; set; }
}

public class PersonalInfoContract
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public PersonalDocumentInfo[] Docs { get; set; }
    public string PlaceOfBirth { get; set; }
    public string Nationality { get; set; }
    public string CountryOfBirth { get; set; }
}

public class PersonalDocumentInfo
{
    public string Type { get; set; }
    public string ValidUntil { get; set; }
    public string SubType { get; set; }
    public string Country { get; set; }
    public string Number { get; set; }
}

public class PersonVerification
{
    public string Level { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class ImmitatePersonVerificationRequest
{
    public Guid PersonId { get; set; }
    public ImitatePersonalInfo Info { get; set; }
    public string IsRepeatStatus { get; set; }
}

public class ImitatePersonalInfo
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Nationality { get; set; }
    public string PlaceOfBirth { get; set; }
    public string DateOfBirth { get; set; }
    public string CountryOfBirth { get; set; }
    public string DocCountry { get; set; }
    public string DocNumber { get; set; }
    public string DocValidUntil { get; set; }
}

public class VerificationResult
{
    public bool IsSuccess => string.IsNullOrEmpty(Error);
    public string Error { get; set; }
}