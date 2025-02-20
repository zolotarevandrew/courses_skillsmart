namespace h_work.lesson93.Example3;

public interface ICountryRegNumberValidationService
{
    public string CountryCode { get; }
    Task<(RegNumberDetails Details, RegNumberValidationErrorGroup Errors)> Validate(RegNumberValidationModel model);
}

public class RegNumberValidationErrorGroup
{
    private readonly List<RegNumberValidationError> _errors;
    private Dictionary<Type, RegNumberValidationError> _byType;
    
    public RegNumberValidationErrorGroup(IEnumerable<RegNumberValidationError> errors)
    {
        _errors = errors.ToList();
        _byType = _errors.ToDictionary(c => c.GetType(), c => c);
    }
    
    public Task TryHandle<TValidationError>(Func<TValidationError, Task> handler)
        where TValidationError : RegNumberValidationError
    {
        var type = typeof(TValidationError);
        return !_byType.TryGetValue(type, out var error)
            ? Task.CompletedTask
            : handler((error as TValidationError)!);
    }
}

public class RegNumberValidationError(string Type, string DefaultText, string LocalizationKey);

public class RegNumberInvalidValidationError() : RegNumberValidationError("RegistrationNumber", "Text", "regNumberInvalid")
{ }

public class RegNumberNotExistInDataSourceValidationError() : RegNumberValidationError("RegistrationNumberNotExistInDataSource", "Text", "regNumberNotInDataSource")
{ }

public class RegNumberAlreadyRegisteredValidationError() : RegNumberValidationError("RegistrationNumberAlreadyRegistered", "Text", "regNumberAlreadyRegistered")
{ }

public class RegistrationIssuerInvalidValidationError() : RegNumberValidationError("RegistrationNumberIssuerInvalid", "Text", "regNumberIssuerInvalid")
{ }

public record RegNumberValidationModel();
public record RegNumberDetails(string Name, string Address);
