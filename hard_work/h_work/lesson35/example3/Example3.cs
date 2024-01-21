using h_work.lesson1.example3;
using Newtonsoft.Json.Linq;

namespace h_work.lesson35.example3;

public class Example3
{
    private readonly IPreOnboardingService _preOnboardingService;

    /*
     * До беспорядочная работа с параметрами компании на предонбординге
     */
    public void Before()
    {
        /*
          var selectedId = request.Id;
        var foundAnnualTurnover = await _dictionariesService.Get(EDictionaryEntity.AnualTurnoverRange, CountryCodes.Netherlands, selectedId);
        if (foundAnnualTurnover == null)
            throw new ContractValidationException("Annual turnover by id was not found");

        var value = foundAnnualTurnover.Metadata["FinomValue"].ToString();
        var isCorporateClient = value.In("RANGE_1m"));

        await _optionStorage.Set(User.Company.Id, OptionKeyEnum.IsScreenAnnualTurnoverShowed.ToString(), true);
        await ChangeCompany(User.Company.Id, User.Id, foundAnnualTurnover, finomValue, isCorporateClient);
         */
    }
 
    public interface IPreOnboardingService
    {
        Task AddParam(PreOnboardingParam param);
        Task<PreOnboardingParamSourceGroup> GetParamSourceGroup(Guid companyId);
        Task<PreOnboardingParamSource> GetParamSource(Guid companyId, EPreOnboardingParamType type);
    }

    public class DictionaryItemContract
    {
        public JObject Metadata { get; }
    }

    public abstract class PreOnboardingParam
    {
        public abstract EPreOnboardingParamType Type { get; }
    }

    public class AnnualTurnoverParam : PreOnboardingParam
    {
        public override EPreOnboardingParamType Type => EPreOnboardingParamType.AnnualTurnover;
        
        public bool IsCorporateClient { get; private set; }

        public AnnualTurnoverParam(DictionaryItemContract foundAnnualTurnover)
        {
            var value = foundAnnualTurnover.Metadata["FinomValue"].ToString();
            IsCorporateClient = value.In("RANGE_1m");
        }
    }

    public class PreOnboardingParamSourceGroup
    {
        
    }

    public enum EPreOnboardingParamType
    {
        AnnualTurnover = 1
    }

    public class PreOnboardingParamSource
    {
        
    }

    public Example3(IPreOnboardingService preOnboardingService)
    {
        _preOnboardingService = preOnboardingService;
    }
    
    /*
     * После - явно выделяем преонбординг параметр а логику синхронизации уносим как асинхронную обработку внутри реализации PreOnboardingService
     * Логика подсчета корпоративного признака вынесена явно и может легко изменена и протестирована
     */

    public async Task After()
    {
        /*
         var selectedId = request.Id;
       var foundAnnualTurnover = await _dictionariesService.Get(EDictionaryEntity.AnualTurnoverRange, CountryCodes.Netherlands, selectedId);
       if (foundAnnualTurnover == null)
           throw new ContractValidationException("Annual turnover by id was not found");

       var annualTurnoverParam = new AnnualTurnoverParam(foundAnnualTurnover);
            _preOnboardingService.AddParam(annualTurnoverParam);
        */
    }
}