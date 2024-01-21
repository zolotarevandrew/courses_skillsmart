namespace h_work.lesson35.example4;

public class Example4
{
    private readonly IPersonMatchService _personMatchService;

    /*
     * До - простановка успешности верификаций
     * здесь важно было посчитать нужно ли перепроверять верификации на основе данных персоны и верификации
     * и смерджить данные в персону из документов с верификации при успешном совпадении
     */
    public void Before()
    {
        /*
         * var risksVerifications = new List<ExtendedPersonVerification>();
        using (var dbConnection = await _dbConnector.OpenConnection(cancellationToken))
        using (var dbTransaction = dbConnection.BeginTransaction())
        {
            try
            {
                if (extendedVerifications.All(x => x.ApplicantInfo is not {Status: ESumSubApplicantStatus.Approved}))
                {
                    throw new Exception("Couldn't find approved verification");
                }

                var notSuccessVerifications = extendedVerifications
                    .Where(c => c.Value.Status != EPersonVerificationStatus.Succeed);
                foreach (var extendedVerification in notSuccessVerifications)
                {
                    if (extendedVerification.ApplicantInfo is not { Status: ESumSubApplicantStatus.Approved }) continue;

                    var sumSubMetadata = await CreateSumSubMetadata(extendedVerification);
                    extendedVerification.Value.Metadata = sumSubMetadata;
                    
                    if (sumSubMetadata.MatchPercent >= _config.MinPercentForNameMatching)
                    {
                        extendedVerification.Value.OuterStatus = "Verified";
                        extendedVerification.Value.Status = EPersonVerificationStatus.Succeed;
                        
                        MergeMetadataToPerson(sumSubMetadata, extendedVerification.Person);

                        if (_config.SyncFullNameByCountry.ContainsKey(dossier.CountryCode))
                        {
                            if (!string.IsNullOrEmpty(sumSubMetadata.FirstName)) extendedVerification.Person.FirstName = sumSubMetadata.FirstName.UpperFirstLettersOnly();
                            if (!string.IsNullOrEmpty(sumSubMetadata.LastName)) extendedVerification.Person.LastName = sumSubMetadata.LastName.UpperFirstLettersOnly();
                        }
                        
                        await _companyPersonStorage.Upsert(dbConnection, dbTransaction, extendedVerification.Person);
                    }
                    else
                    {
                        extendedVerification.Value.OuterStatus = "Verified";
                        extendedVerification.Value.Status = EPersonVerificationStatus.NeedReview;
                    }
                    risksVerifications.Add(extendedVerification);
                    await _personsVerificationsStorage.Upsert(dbConnection, dbTransaction, extendedVerification.Value);
                }

                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw;
            }
        }
        
        await ApplyRisks(risksVerifications, companyId.Value, userId.Value);
         */
    }

    public record MatchedPersonsResult
    {
        public EPersonMatchType Type { get; init; }
        public int MatchPercent { get; init;}
        public bool IsDatesMatched { get; init;}
    }

    public enum EPersonMatchType
    {
        DatesMismatch,
        NamesMismatch,
        FullMatch
    }

    public interface IMatchPerson
    {
        string FirstName { get; }
        string LastName { get; }
        DateTime? BirthDate { get; }
    }

    public interface IPersonMatchService
    {
        Task<MatchedPersonsResult> Match(IMatchPerson one, IMatchPerson two);
    }
    
    /*
     * После -рефакторинг
     * Заводим явную абстракцию матчинга (завели просто для переиспользования в других местах, будет использовать общий алгоритм матчинга)

     * 
     * На основе абстракции матчинга - выделим явную абстракцию проверки верификации персоны
     */
    public record PersonVerification
    {
        public Guid CompanyId { get; init; }
        public PersonVerificationStatus Status { get; init; }
        public PersonVerificationDocument Document { get; init; }
    }
    
    public class PersonVerificationDocument : IMatchPerson
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime? BirthDate { get; init; }
        public string IdNumber { get; init; }
        public DateTime? ValidUntil { get; init; }
    }

    public record Person : IMatchPerson
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime? BirthDate { get; init; }

        public Person MergeFrom(PersonVerificationDocument document)
        {
            //Всегда мерджим все данные, всеравно нам нужны данные из документов
            return this with
            {
                FirstName = document.FirstName,
                LastName = document.LastName,
                BirthDate = document.BirthDate
            };
        }
    }

    public enum PersonVerificationStatus
    {
        Success,
        NeedReview
    }

    public Example4(IPersonMatchService personMatchService)
    {
        _personMatchService = personMatchService;
    }

    public async Task After()
    {
        var verification = new PersonVerification();
        var person = new Person();
        
        var matchResult = await _personMatchService.Match(verification.Document, person);
        if (matchResult.Type == EPersonMatchType.FullMatch)
        {
            var succeededVerification = verification with
            {
                Status = PersonVerificationStatus.Success
            };
            person.MergeFrom(succeededVerification.Document);
            //Save data
            return;
        }
        
        var needReviewVerification = verification with
        {
            Status = PersonVerificationStatus.NeedReview
        };
        //Save data
    }
}