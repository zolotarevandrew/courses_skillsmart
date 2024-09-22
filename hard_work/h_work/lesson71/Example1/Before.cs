namespace h_work.lesson71.Example1;

public interface IBeforeTaxNumberValidator
{
    Task Validate(string taxNumber, string countryCode);
    Task ValidateFreelancer(string taxNumber, string countryCode);
    Task ValidateComplex(string taxNumber);
}