
using Example1.Module1;

namespace Example1.Module1
{
    public record RiskEntity(string Type, string EntityId);
    public record RiskScore(decimal Score);
    public interface IRiskEngine
    {
        Task<RiskScore> CalcBaseRisk(RiskEntity entity);
    }
    public record SuggestedRiskScore(decimal Score);
    
    public interface ISuggestedRiskCalculator
    {
        IRiskEngine RiskEngine();
        
        public Task<SuggestedRiskScore> Calc(RiskEntity entity)
        {
            var baseRisk = RiskEngine().CalcBaseRisk(entity);
            //tbd custom by entity calculation;
            return null;
        }
    }
}

namespace Example1.Module2
{
    public interface ITicketService
    {
        
    }

    public class TicketRiskEngine : IRiskEngine
    {
        public Task<RiskScore> CalcBaseRisk(RiskEntity entity)
        {
            throw new NotImplementedException();
        }
    }
    
    public class SpecificTicketService : ITicketService, ISuggestedRiskCalculator
    {
        private readonly TicketRiskEngine _riskEngine;

        public SpecificTicketService(TicketRiskEngine riskEngine)
        {
            _riskEngine = riskEngine;
        }

        IRiskEngine ISuggestedRiskCalculator.RiskEngine() => _riskEngine;

        public Task Calc(RiskEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
