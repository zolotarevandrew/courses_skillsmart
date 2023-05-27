using System.Collections;
using Newtonsoft.Json.Linq;

namespace h_work.lesson4.example2
{
    public class PrepareSanctionsCheckSourceHandler
    {
        private readonly IRiskService _riskService;
        private readonly ICompanyService _cddService;
        private readonly IScreeningService _screeningService;
        private readonly ISharedDataService _sharedDataService;
        private readonly ISanctionListsService _sanctionListsService;

        public PrepareSanctionsCheckSourceHandler(
            ICompanyService cddService, 
            IScreeningService screeningService, 
            ISharedDataService sharedDataService, 
            ISanctionListsService sanctionListsService, 
            IRiskService riskService)
        {
            _cddService = cddService;
            _screeningService = screeningService;
            _sharedDataService = sharedDataService;
            _sanctionListsService = sanctionListsService;
            _riskService = riskService;
        }

        public async Task<List<SanctionsCheckSource>> Prepare(Guid companyId)
        {
            var companyData = await _cddService.Get(companyId);

            List<SanctionsCheckSource> checkSource = new();

            var sharedKey = new AddSharedDataResult();
            var sanctionLists = await _sanctionListsService.Get(ESanctionsType.Sanctions);
            sharedKey.Key = _sharedDataService.BuildKey(companyData.Id,
                        companyData.RegisteredName,
                        EParameterType.CompanyRegisteredName,
                        null);
            var screenedRegName = await _screeningService.Screen(
                new ScreenDataRequest(companyData.Id,
                    companyData.RegisteredName,
                    sharedKey.Key,
                    true)
            );

            if (screenedRegName.HasSanctionsType(sanctionLists))
            {
                sharedKey = await _sharedDataService.AddScreeningCompanyData(companyData.Id,
                    companyData.RegisteredName,
                    EParameterType.CompanyRegisteredName,
                    null, screenedRegName);
                checkSource.Add(
                    new SanctionsCheckSource
                    {
                        EntityId = companyData.Id,
                        EntityType = EEntityType.Company,
                        Parameter = EParameterType.CompanyRegisteredName,
                        Options = new SanctionsCheckOptions
                        {
                            Value = companyData.RegisteredName,
                            SharedKey = sharedKey.Key,
                        },
                    });
                sharedKey.Key = null;
            }
            else
            {
                await InitEmptyRisk(companyId,
                    companyData.Id,
                    EEntityType.Company,
                    EParameterType.CompanyRegisteredName,
                    null);
            }

            foreach (var tradeName in companyData.TradeNames)
            {
                sharedKey.Key = _sharedDataService.BuildKey(companyData.Id,
                        tradeName,
                        EParameterType.CompanyTradingName,
                        tradeName.ToString());
                var screened = await _screeningService.Screen(new ScreenDataRequest(companyData.Id, tradeName, sharedKey.Key, true));
                if (!screened.HasSanctionsType(sanctionLists))
                {
                    await InitEmptyRisk(companyId,
                        companyId,
                        EEntityType.Company,
                        EParameterType.CompanyTradingName, null);
                    continue;
                }

                sharedKey = await _sharedDataService.AddScreeningCompanyData(companyData.Id,
                    tradeName,
                    EParameterType.CompanyTradingName,
                    tradeName, screened);

                checkSource.Add(new SanctionsCheckSource
                {
                    EntityId = companyData.Id,
                    EntityType = EEntityType.Company,
                    Parameter = EParameterType.CompanyTradingName,
                    ParameterId = tradeName.ToString(),
                    Options = new SanctionsCheckOptions
                    {
                        Value = tradeName,
                        SharedKey = sharedKey.Key,
                    },
                });
                sharedKey.Key = null;
            }

            foreach (var person in companyData.Persons)
            {
                var personType = EPersonType.None;
                if (person.IsLegalRepresentative)
                {
                    personType |= EPersonType.LegalRepsentative;
                }
                if (person.IsBeneficiary)
                {
                    personType |= EPersonType.Ubo;
                }

                if (person.IsShareholder)
                {
                    personType |= EPersonType.Shareholder;
                }

                sharedKey.Key = _sharedDataService.BuildKey(person.Id,
                        $"{person.FirstName} {person.LastName}",
                        EParameterType.PersonFullName,
                        null);
                var screened = await _screeningService.Screen(new ScreenDataRequest(person.Id, $"{person.FirstName} {person.LastName}", sharedKey.Key, false));
                if (!screened.HasSanctionsType(sanctionLists))
                {
                    await InitEmptyRisk(companyId,
                        person.Id,
                        EEntityType.Person,
                        EParameterType.PersonFullName,
                        null);
                    continue;
                }

                sharedKey = await _sharedDataService.AddScreeningPersonData(person.Id,
                    $"{person.FirstName} {person.LastName}",
                    EParameterType.PersonFullName,
                    null, screened);

                checkSource.Add(new SanctionsCheckSource
                {
                    EntityId = person.Id,
                    EntityType = EEntityType.Person,
                    Parameter = EParameterType.PersonFullName,
                    PersonType = personType,
                    Options = new SanctionsCheckOptions
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        CountryOfBirth = person.CountryOfBirth,
                        DateOfBirth = person.DateOfBirth,
                        Nationality = person?.Nationality,
                        SharedKey = sharedKey.Key,
                    },
                });
                sharedKey.Key = null;
            }

            return checkSource;
        }

        private async Task InitEmptyRisk(Guid companyId,
            Guid entityId,
            EEntityType cddEntityType, 
            EParameterType parameter, 
            Guid? parameterId)
        {
            await _riskService.Init(new InitRiskRequest
            {
                CompanyId = companyId,
                EntityId = entityId,
                EntityType = cddEntityType,
                Parameter = parameter,
                ParameterId = parameterId
            });
        }
    }

    public class InitRiskRequest
    {
        public Guid CompanyId { get; set; }
        public Guid EntityId { get; set; }
        public EEntityType EntityType { get; set; }
        public EParameterType Parameter { get; set; }
        public Guid? ParameterId { get; set; }
    }

    public interface IRiskService
    {
        Task Init(InitRiskRequest initRiskRequest);
    }

    public interface ISanctionListsService
    {
        Task<SanctionList> Get(ESanctionsType sanctions);
    }

    public class SanctionList
    {
        
    }

    public interface ISharedDataService
    {
        Task<AddSharedDataResult> AddScreeningPersonData(Guid id, string s, EParameterType personFullName, object o, object? screened);
        Task<AddSharedDataResult> AddScreeningCompanyData(Guid companyDataId, string tradeName, EParameterType companyTradingName, string p3, object? screened);
        string BuildKey(Guid entityId, string value, EParameterType parameterType, string parameterValue);
    }

    public interface IScreeningService
    {
        Task<ScreenResult> Screen(ScreenDataRequest p0);
    }

    public class ScreenResult
    {
        public bool HasSanctionsType(SanctionList list)
        {
            return false;
        }
    }

    public interface ICompanyService
    {
        Task<CompanyData> Get(Guid companyId);
    }

    public class CompanyData
    {
        public Guid Id { get; set; }
        public string RegisteredName { get; set; }
        public List<string> TradeNames { get; set; }
        public List<CompanyPerson> Persons { get; set; }
    }

    public class CompanyPerson
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLegalRepresentative { get; set; }
        public bool IsBeneficiary { get; set; }
        public bool IsShareholder { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string CountryOfBirth { get; set; }
    }

    public class ScreenDataRequest
    {
        public ScreenDataRequest(Guid id, string name, string sharedKey, bool isOrganization)
        {
            throw new NotImplementedException();
        }
    }

    public class AddSharedDataResult
    {
        public string Key { get; set; }
    }

    public class SanctionsCheckOptions
    {
        public string SharedKey { get; set; }
        public string Value { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryOfBirth { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
    }

    public class SanctionsCheckSource
    {
        public Guid EntityId { get; set; }
        public EEntityType EntityType { get; set; }
        public EParameterType Parameter { get; set; }
        public EPersonType PersonType { get; set; }
        public SanctionsCheckOptions Options { get; set; }
        public string ParameterId { get; set; }
    }

    public class AdditionalParameterData
    {
        public Guid EntityId { get; set; }
        public EEntityType EntityType { get; set; }
        public EParameterType Parameter { get; set; }
        public Guid? ParameterId { get; set; }
        public Guid RootEntityId { get; set; }
    }

    public enum ESanctionsType
    {
        Sanctions = 1
    }

    public enum EEntityType
    {
        LegalEntity,
        Company,
        Person
    }
    
    public enum EParameterType
    {
        CompanyRegisteredName,
        LegalEntityName,
        PersonFullName,
        CompanyTradingName
    }

    [Flags]
    public enum EPersonType
    {
        None,
        LegalRepsentative,
        Ubo,
        Shareholder
    }
}
