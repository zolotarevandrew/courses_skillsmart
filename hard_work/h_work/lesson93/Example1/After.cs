

namespace h_work.lesson93.Example1;

public class FreelancerBusinessDetailsExecuteDataContract
{
    public bool AgreeToTerms { get; set; }
    public DateTime? RegistrationDate { get; set; }
}

public class After
{
    public IReadOnlyCollection<ValidationError> Validate(
        FreelancerBusinessDetailsExecuteDataContract contract)
    {
        var scope = contract.CreateValidationScope();
        scope.Add(c => c.AgreeToTerms.ContractEqual(true, "AgreeToTerms is not selected"));
        scope.Add(c => c.RegistrationDate.ContractMust(
                t => t is not null,
                () => new ValidationError("RegistrationDate", "Registration date is required.",
                    "common.validators.registrationDateRequired")
            )
        );
        scope.Add(c => c.RegistrationDate.ContractMust(
            t => t <= DateTime.Today,
            () => new ValidationError("RegistrationDate", "Registration date must be less current date.",
                "common.validators.registrationDateLessNow")
        ));

        return scope.Result();
    }
}

public class ValidationScope<TContract>
{
    private readonly List<ValidationError> _errors = new();
    private readonly TContract _source;
    
    internal ValidationScope(TContract source)
    {
        _source = source;
    }

    public IReadOnlyCollection<ValidationError> Result()
    {
        return _errors;
    }

    public void Add(Func<TContract, ValidationError> validation) 
    {
        var error = validation.Invoke(_source);
        if (error == ValidationError.Empty) return;
        
        _errors.Add(error);
    }
}

public static class ValidationScopeFactory
{
    public static ValidationScope<T> CreateValidationScope<T>(this T contract) where T : class
    {
        return new ValidationScope<T>(contract);
    }
}

public record ValidationError
{
    public string Code { get; }
    public string Message { get; }
    public string LocalizationKey { get; }

    public ValidationError(string code, string message, string localizationKey)
    {
        Code = code;
        Message = message;
        LocalizationKey = localizationKey;
    }

    public static ValidationError Empty => new ValidationError(string.Empty, string.Empty, string.Empty);
}
public static class ValidationExtensions
{
    public static ValidationError ContractEqual<T>(this T obj, T value, string message)
    {
        return !obj.Equals(value) ? new ValidationError(string.Empty, message, string.Empty) : ValidationError.Empty;
    }
    
    public static ValidationError ContractMust<T>(this T obj, Func<T, bool> predicate, Func<ValidationError> createError)
    {
        return predicate(obj) ? createError() : ValidationError.Empty;
    }
}