
using h_work.lesson9.example6;

namespace Example3.Module1
{
    public record VerificationGroup();
    public interface IVerificationStep
    {
        public Task<VerificationGroup> GetVerificationGroup(IBankOnboardingContext context)
        {
            throw new NotImplementedException();
        }
    }

    public record DocumentGroup();
    public interface IDocumentsStep
    {
        public Task<DocumentGroup> GetDocuments(IBankOnboardingContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class SpecificStep : IDocumentsStep, IVerificationStep
    {
        
    }
}

