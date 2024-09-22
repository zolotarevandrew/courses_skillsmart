namespace h_work.lesson71.Example1;

public interface ICompanyTaxNumberValidator
{
    Task Validate(string taxNumber, string countryCode);
}

public interface IFreelancerTaxNumberValidator
{
    Task Validate(string taxNumber, string countryCode);
}

public interface IComplexCompanyTaxNumberValidator
{
    Task Validate(string taxNumber, string countryCode);
}