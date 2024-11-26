

public class Before1
{
    /*
     * private SaveBusinessActivityQuestionnaireRequest PrepareByData(Guid companyId, Guid userId, ComplexQuestionnaireData data)
    {
        var request = new SaveBusinessActivityQuestionnaireRequest
        {
            CompanyId = companyId,
            TypeOfActivity = MapType(data.BusinessActivity.BusinessActivityType),
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

        if (data.BusinessActivity.BusinessActivityType == EComplexBusinessActivityType.ServiceIndustry)
        {
            request.ServiceIndustry = new ServiceIndustryQuestionnaire
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
        if (data.BusinessActivity.BusinessActivityType == EComplexBusinessActivityType.SaleOfGoods)
        {
            request.SaleOfGoods = new SaleOfGoodsQuestionnaire
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
        if (data.BusinessActivity.BusinessActivityType == EComplexBusinessActivityType.InvestmentCompany)
        {
            request.InvestmentCompany = new InvestmentCompanyQuestionnaire
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
        if (data.BusinessActivity.BusinessActivityType == EComplexBusinessActivityType.HoldingCompany)
        {
            request.HoldingCompany = new HoldingCompanyQuestionnaire
            {
                GroupRole = data.HoldingCompany.GroupRole
            };
        }

        return request;
        ETypeOfActivity MapType(EComplexBusinessActivityType businessActivityType)
        {
            return businessActivityType switch
            {
                EComplexBusinessActivityType.None => ETypeOfActivity.None,
                EComplexBusinessActivityType.ServiceIndustry => ETypeOfActivity.ServiceIndustry,
                EComplexBusinessActivityType.SaleOfGoods => ETypeOfActivity.SaleOfGoods,
                EComplexBusinessActivityType.HoldingCompany => ETypeOfActivity.HoldingCompany,
                EComplexBusinessActivityType.InvestmentCompany => ETypeOfActivity.InvestmentCompany,
            };
        }
    }
     */
}