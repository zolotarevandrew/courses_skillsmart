namespace h_work.lesson12.example1;

public interface IMissingInformationProcessNotifierV2
{
    Task<bool> Notify(OpeningAccountKYCProcess kycProcess);
}

public record OpeningAccountProcess(Guid CompanyId, Guid OnboardingId, Guid UserId);
public record OpeningAccountKYCProcess(Guid CompanyId, Guid OnboardingId, Guid UserId);

public interface IOpeningAccountProcessServiceV2 : IMissingInformationProcessNotifierV2
{
    Task<OpeningAccountProcess> FindProcess(Guid companyId);
    Task<OpeningAccountKYCProcess> FindKycProcess(Guid companyId);
    
    Task Start(OpeningAccountProcess existingProcess);
    
    Task<bool> UserCheckedLr(OpeningAccountKYCProcess kycProcess);
    Task<bool> UserSelectedHimself(OpeningAccountKYCProcess kycProcess);
    Task<bool> AllStepsCompleted(OpeningAccountKYCProcess kycProcess, AllStepsCompletedRequest request);
}