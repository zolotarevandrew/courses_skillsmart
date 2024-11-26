namespace h_work.lesson82.Example1;

public class After
{
    /*
     private SaveBusinessActivityQuestionnaireRequest PrepareByData(Guid companyId, Guid userId, ComplexQuestionnaireData data)
    {
        var activityFiller = GetActivityFiller(data);
        var request = new SaveBusinessActivityQuestionnaireRequest
        {
            CompanyId = companyId,
            TypeOfActivity = activityFiller.Item1,
            CompanyWebsite = data.BusinessActivity.Website,
            Initiator = new DossierChangeInitiator
            {
                Channel = EDataChangeChannel.BankOnboarding,
                Source = ECddChangeSource.Customer,
                UserId = userId
            },
            ReasonToOpenAccount = data.BusinessActivity.OpeningAccountReason,
            Contact = data.BusinessActivity.Contact,
        };
        activityFiller.activityFiller(request);
        return request;
    }
    
    static (ETypeOfActivity, Action<SaveBusinessActivityQuestionnaireRequest> activityFiller) GetActivityFiller(ComplexQuestionnaireData data)
    
    {
        return data.BusinessActivity.BusinessActivityType switch
        {
            EComplexBusinessActivityType.None => 
                (ETypeOfActivity.None, (d) => {}),
            EComplexBusinessActivityType.ServiceIndustry => 
                (ETypeOfActivity.ServiceIndustry, (r) => r.ServiceIndustry = RequestServiceIndustry(data)),
            EComplexBusinessActivityType.SaleOfGoods => 
                (ETypeOfActivity.SaleOfGoods, (r) => r.SaleOfGoods = RequestSaleOfGoods(data)),
            EComplexBusinessActivityType.HoldingCompany => 
                (ETypeOfActivity.HoldingCompany, (r) => r.InvestmentCompany = RequestInvestmentCompany(data)),
            EComplexBusinessActivityType.InvestmentCompany => 
                (ETypeOfActivity.InvestmentCompany, (r) => r.HoldingCompany = RequestHoldingCompany(data)),
        };
    }

    private static HoldingCompanyQuestionnaire RequestHoldingCompany(ComplexQuestionnaireData data)
    {
        return new HoldingCompanyQuestionnaire
        {
            GroupRole = data.HoldingCompany.GroupRole
        };
    }

    private static InvestmentCompanyQuestionnaire RequestInvestmentCompany(ComplexQuestionnaireData data)
    {
        return new InvestmentCompanyQuestionnaire
        {
            SourceOfInvestmentFund = data.InvestmentCompany.SourceOfInvestmentFund,
            SourceOfInvestmentFundsText = data.InvestmentCompany.SourceOfInvestmentFundsText,
            CorporateAffiliation = data.InvestmentCompany.CorporateAffiliation,
            CorporateAffiliationText = data.InvestmentCompany.CorporateAffiliationText,
            Cryptocurrency = data.InvestmentCompany.Cryptocurrency,
            CryptocurrencyText = data.InvestmentCompany.CryptocurrencyText,
            InvestmentPortfolioComposition = data.InvestmentCompany.InvestmentPortfolioComposition,
            InvestmentPortfolioOverview = data.InvestmentCompany.InvestmentPortfolioOverview,
            LicenseLink = data.InvestmentCompany.LicenseLink,
            LicenseRequired = data.InvestmentCompany.LicenseRequired,
            TotalAmountOfAssetsUnderManagement = data.InvestmentCompany.TotalAmountOfAssetsUnderManagement
        };
    }

    private static SaleOfGoodsQuestionnaire RequestSaleOfGoods(ComplexQuestionnaireData data)
    {
        return new SaleOfGoodsQuestionnaire
        {
            CountriesOfWarehouseProductionSite = data.SaleOfGoods.CountriesOfWarehouseProductionSite,
            TypeOfProductSell = data.SaleOfGoods.TypeOfProductSell,
            AdvertisingApproach = data.SaleOfGoods.AdvertisingApproach,
            BusinessActivityDescription = data.SaleOfGoods.BusinessActivityDescription,
            CustomerAcquisition = data.SaleOfGoods.CustomerAcquisition,
            DeliveryMethod = data.SaleOfGoods.DeliveryMethod,
            LicenseLink = data.SaleOfGoods.LicenseLink,
            LicenseRequired = data.SaleOfGoods.LicenseRequired,
            NumberOfEmployees = (int)data.SaleOfGoods.NumberOfEmployees,
            ProvidingChannelAndMechanicsText = data.SaleOfGoods.ProvidingChannelAndMechanicsText
        };
    }

    private static ServiceIndustryQuestionnaire RequestServiceIndustry(ComplexQuestionnaireData data)
    {
        return new ServiceIndustryQuestionnaire
        {
            LabourStructure = data.ServiceIndustry.LabourStructure,
            TypeOfRenderService = data.ServiceIndustry.TypeOfRenderService,
            AdvertisingApproach = data.ServiceIndustry.AdvertisingApproach,
            BusinessActivityDescription = data.ServiceIndustry.BusinessActivityDescription,
            CustomerAcquisition = data.ServiceIndustry.CustomerAcquisition,
            LicenseLink = data.ServiceIndustry.LicenseLink,
            LicenseRequired = data.ServiceIndustry.LicenseRequired,
            NumberOfEmployees = (int)data.ServiceIndustry.NumberOfEmployees,
            ProvidingChannelAndMechanicsText = data.ServiceIndustry.ProvidingChannelAndMechanicsText,
        };
    }
     */
}