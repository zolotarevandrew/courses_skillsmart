namespace h_work.lesson56.Example2;

public class LongFunction
{
    private async Task FillRootCompanyInfo(Guid companyId, RegistrationNumberTreeInfo treeInfo, Guid? userId)
    {
        #region LoadExistingData
        var foundCompanyTask = _dossierStorageService.Get(companyId);
        var foundWebSitesTask = _dossierStorageService.GetCompanyWebsites(companyId);
        var foundTradeNamesTask = _dossierStorageService.GetCompanyTradeNames(companyId);
        var existingPersonsTask = _companyPersonStorage.GetByCompanyId(companyId);
        var existAddressesTask = _sharingEntitiesStorage.GetAddressesByEntityIds(new[] { companyId });
        var countryCodeOrDefault = await _industryCacheService.GetCountryCodeOrDefault(treeInfo.CountryCode);
        var industriesTask = _industryCacheService.GetAllIndustries(countryCodeOrDefault);
        var existLegalEntitiesTask = _legalEntitiesStorage.GetByCompanyId(companyId);
        var foundEmailsTask = _sharingEntitiesStorage.GetEmailsByEntityIds(new[] { companyId });

        await Task.WhenAll(foundCompanyTask,
            foundWebSitesTask,
            foundTradeNamesTask,
            existingPersonsTask,
            existAddressesTask,
            industriesTask,
            existLegalEntitiesTask,
            foundEmailsTask);

        var foundCompany = foundCompanyTask.Result;
        var foundWebSites = foundWebSitesTask.Result.ToList();
        var foundTradeNames = foundTradeNamesTask.Result.ToList();
        var existingPersons = existingPersonsTask.Result.ToList();
        var existAddresses = existAddressesTask.Result.ToList();
        var existLegalEntities = existLegalEntitiesTask.Result.ToList();
        var foundEmails = foundEmailsTask.Result.ToList();
        
        var response = await _bizDataSourceService.GetCompanyInfo(new BizDataCompanyRequest
        {
            CompanyId = companyId,
            CountryCode = treeInfo.CountryCode,
            RegNumber = treeInfo.RegistrationNumber,
            Name = treeInfo.CompanyName,
            RegistrationIssuer = treeInfo.RegistrationIssuer?.Id,
        });
        #endregion


        #region InitContext

        var requestContext = new InternalRequestContext
        {
            ClientInfo = new RequestClientInfo(),
            CurrentUser = new InternalUserInfo(),
        };

        var context = new DossierQuestionnaireEditionContext(requestContext, new List<LegalForm>(), industriesTask.Result.ToList());
        context.TryAddData(nameof(DateTime.UtcNow), _dateTime.UtcNow);

        var initiator = new DossierChangeInitiator
        {
            Channel = EDataChangeChannel.BankOnboarding,
            Source = ECddChangeSource.BusinessRegister,
        };


        context.TryAddData(nameof(DossierChangeInitiator), initiator);

        #endregion
        
        var lockKey = LockKeyGetter.GetForCompanyUpsert(companyId);
        using (await _distributedLockFactory.AcquireLockAsync(lockKey, TimeSpan.FromSeconds(30)))
        {
            using (var dbConnection = await _dbConnector.OpenConnection(CancellationToken.None))
            {
                using (var dbTransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        if (response.IsSuccess)
                        {
                            #region ProcessSucceded
var bizDataCompany = response.Response;
                            if (bizDataCompany.Flags.UnregisteredRegNumber)
                            {
                                initiator.Source = ECddChangeSource.Customer;
                                initiator.UserId = userId;
                            }

                            var (companyIndustries, mainIndustry) =
                                await _industryProcessor.ProcessCompanyIndustries(companyId, bizDataCompany.Activities, context);

                            var industries = await _industryProcessor.ProcessIndustries(bizDataCompany.Activities, treeInfo.CountryCode);

                            var company = await CreateCompany(foundCompany, treeInfo, companyId, bizDataCompany, context, mainIndustry);
                            var websites = CreateWebsites(foundWebSites, companyId, bizDataCompany, context);
                            var tradeNames = CreateTradeNames(foundTradeNames, companyId, bizDataCompany, context);
                            
                            var foundPersonsWithCompanyRelations = bizDataCompany.Persons.Select(x => (x,  BusinessRelation.CreateNew(companyId, ECddEntityType.Company, true, CompanyRelationTypeConverter.ToDomain(x.CompanyRelationType))));

                            var (personsToUpsert, personsDataSourcesToStore, personsAuditMessages) =
                                _personCreatorService.CreateOrUpdatePersons(companyId, existingPersons, foundPersonsWithCompanyRelations, initiator);

                            context.DataSourcesToStore.AddRange(personsDataSourcesToStore);
                            context.ValueChangedLogsToStore.AddRange(personsAuditMessages);
                            if (personsToUpsert.Count > _onboardingConfig.MaxPersonsThreshold)
                            {
                                await _maxThresholdReachedNotifier.Notify(companyId,
                                    company.RegisteredName,
                                    company.CountryCode,
                                    MaxThresholdType.Person,
                                    personsToUpsert.Count);

                                throw new Exception("Max person threshold has been reached");
                            }
                            
                            var foundLegalEntitiesWithCompanyRelations = bizDataCompany.Persons.Where(x => x.Type == EBizDataCompanyPersonType.LegalEntity)
                                .Select(x => (x, BusinessRelation.CreateNew(companyId, ECddEntityType.Company, true, CompanyRelationTypeConverter.ToDomain(x.CompanyRelationType))));
                            
                            var (entitiesToUpsert, legalEntitiesDataSourcesToStore, legalEntitiesAuditMessages) =
                                _legalEntityCreatorService. CreateLegalEntities(companyId, initiator, existLegalEntities, foundLegalEntitiesWithCompanyRelations);
                            
                            context.DataSourcesToStore.AddRange(legalEntitiesDataSourcesToStore);
                            context.ValueChangedLogsToStore.AddRange(legalEntitiesAuditMessages);
                            if (entitiesToUpsert.Count > _onboardingConfig.MaxLegalEntitiesThreshold)
                            {
                                await _maxThresholdReachedNotifier.Notify(companyId,
                                    company.RegisteredName,
                                    company.CountryCode,
                                    MaxThresholdType.LegalEntity,
                                    entitiesToUpsert.Count);

                                throw new Exception("Max legal entities threshold has been reached");
                            }

                            var addresses = CreateAddresses(existAddresses, companyId, bizDataCompany, context);
                            var emails = CreateEmails(foundEmails, companyId, bizDataCompany, context);

                            await _dossierStorageService.Upsert(dbConnection, dbTransaction, company);

                            foreach (var website in websites)
                            {
                                await _dossierStorageService.Upsert(dbConnection, dbTransaction, website);
                            }

                            await _industryProcessor.Save(dbConnection, dbTransaction, industries);
                            await _industryProcessor.Save(dbConnection, dbTransaction, companyIndustries);
                            await _industryProcessor.Save(dbConnection, dbTransaction, companyId, bizDataCompany.ActivityDescription);

                            foreach (var tradeName in tradeNames)
                            {
                                await _dossierStorageService.Upsert(dbConnection, dbTransaction, tradeName);
                            }

                            foreach (var person in personsToUpsert)
                            {
                                await _companyPersonStorage.Upsert(dbConnection, dbTransaction, person);
                            }

                            foreach (var address in addresses)
                            {
                                await _sharingEntitiesStorage.Upsert(dbConnection, dbTransaction, address);
                            }

                            foreach (var legalEntity in entitiesToUpsert)
                            {
                                await _legalEntitiesStorage.Upsert(dbConnection, dbTransaction, legalEntity);
                            }

                            foreach (var email in emails)
                            {
                                await _sharingEntitiesStorage.Upsert(dbConnection, dbTransaction, email);
                            }
                            

                            #endregion
                        }
                        else
                        {
                            #region ProcessError
                            foundCompany = await _dossierStorageService.Get(companyId);
                            if (foundCompany == null)
                            {
                                var company = await CreateErrorCompany(treeInfo, companyId, context);
                                await _dossierStorageService.Upsert(dbConnection, dbTransaction, company);
                            }
                            else
                            {
                                var metadata = new JObject
                                {
                                    [MetadataKeys.CompanyInfoErrorFromKvk] = true,
                                };

                                await _dossierStorageService.ExtendMetadata(dbConnection, dbTransaction, companyId, metadata);
                            }
                            

                                #endregion
                            
                        }

                        await _dataSourceStorageService.Upsert(dbConnection, dbTransaction, context.DataSourcesToStore);

                        dbTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        throw;
                    }
                }
            }
        }

        #region SendLogs
        var logTasks = new List<Task>();
        foreach (var storeLogMessage in context.ValueChangedLogsToStore)
        {
            var task = _hydeParkPublisher.PublishAsync(storeLogMessage, CancellationToken.None);
            logTasks.Add(task);
        }

        if (context.UpdateCompanyRequest.IsDirty())
        {
            context.UpdateCompanyRequest.Id = companyId;
            var task = _publisher.PublishAsync(new UpdateCompanyMessage
            {
                UpdateCompanyRequest = context.UpdateCompanyRequest,
            });

            logTasks.Add(task);
        }

        if (context.BusinessTypeChanged.Any())
        {
            foreach (var msg in context.BusinessTypeChanged)
            {
                var task = _hydeParkPublisher.PublishAsync(msg, CancellationToken.None);
                logTasks.Add(task);
            }
        }

        await Task.WhenAll(logTasks);
        

        #endregion
       
    }
}
