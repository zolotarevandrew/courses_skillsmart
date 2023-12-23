namespace h_work.lesson31.example4;

public interface IDataValidator<TModel> where TModel: ValidationModel
{
    Task Validate(TModel model);
}

public abstract class ValidationModel {}

public class LegalFormValidationModel : ValidationModel
{
    public Guid Id { get; init; }
    public string CountryCode { get; init; }
}

public class V2LegalFormValidator : IDataValidator<LegalFormValidationModel>
{
    public Task Validate(LegalFormValidationModel data)
    {
        throw new NotImplementedException();
    }
}

public interface IDataValidatorFactory
{
    Task ValidateBy<TModel>(TModel data) where TModel : ValidationModel;
}