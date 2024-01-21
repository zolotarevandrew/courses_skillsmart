namespace h_work.lesson35.example5;

public class Example5
{
    private readonly ITeamMemberService _teamMemberService;

    /*
     * До - приглашение тим мемберов в команду
     */
    public void Before()
    {
        /*
         * CompanyPersonInStorage person = await SearchPerson(contract);

            person ??= new CompanyPersonInStorage
            {
                Id = Guid.NewGuid(),
                CompanyId = contract.CompanyId,
                PhoneCode = contract.PhoneCode,
                PhoneNumber = contract.PhoneNumber,
                FirstName = contract.FirstName,
                LastName = contract.LastName
            };
            person.UserId = contract.UserId;
            
            var lockKey = LockKeyGetter.GetForPersonUpsert(person.Id);

            using var locker = await _distributedLockFactory.AcquireLockAsync(lockKey, TimeSpan.FromSeconds(30));

            using (var dbConnection = await _dbConnector.OpenConnection(CancellationToken))
            {
                using (var dbTransaction = dbConnection.BeginTransaction())
                {
                    try
                    { 
                        await _companyPersonStorage.Upsert(dbConnection, dbTransaction, person);
                        dbTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbTransaction.Rollback();
                        throw;
                    }
                }
            }

            return new AcceptedInviteUserResponse
            {
                PersonId = person.Id,
                IsLegalRepresentative = person.IsLegalRepresentative ?? false
            };
        }

        async Task<CompanyPersonInStorage> SearchPerson(AcceptedInviteUserRequest rq)
        {
            var persons = await _companyPersonStorage.GetByCompanyId(rq.CompanyId);

            if (rq.PersonId.HasValue)
            {
                return persons.FirstOrDefault(x => x.Id == rq.PersonId);
            }

            return persons
                .FirstOrDefault(x => StringComparator.GetPercentageDiff($"{x.FirstName} {x.LastName}", $"{rq.FirstName} {rq.LastName}") <= rq.DiffNameThreshold);
        }
         */
    }
    


    public record TeamMember
    {
        public Person Person { get; init; }
        public TeamMember ConnectToUser(Guid userId)
        {
            return this with
            {
                Person = this.Person with
                {
                    UserId = userId
                }
            };
        }
    }

    public record Person
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public bool IsLegalRepresentative { get; init; }
        public Guid? UserId { get; init; }
    }

    public interface ITeamMemberService
    {
        Task<TeamMember?> SearchByPerson(Guid companyId, Guid personId);
        Task AcceptInvite(TeamMember teamMember);
    }
    
    /*
     * После - производим рефакторинг описываем абстракцию приглашения тиммемберов
     * Разделяем выполнение схожих методов, потому что флоу отличается по спецификации
    */

    public Example5(ITeamMemberService teamMemberService)
    {
        _teamMemberService = teamMemberService;
    }

    public async Task After()
    {
        var companyId = Guid.NewGuid();
        var personId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        
        var foundExistingTeamMember = await _teamMemberService.SearchByPerson(companyId, personId);
        if (foundExistingTeamMember != null)
        {
            var connectedTeamMember = foundExistingTeamMember.ConnectToUser(userId);
            await _teamMemberService.AcceptInvite(connectedTeamMember);
            return;
        }

        var newTeamMember = new TeamMember
        {
            Person = new Person
            {
                //set new fields
            }
        };
        newTeamMember.ConnectToUser(userId);
        await _teamMemberService.AcceptInvite(newTeamMember);
    }
}