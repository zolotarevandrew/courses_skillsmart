namespace h_work.lesson93.Example4;

/*
 * public interface IReusablePersonVerificationService
{
    Task<FoundVerifiedPerson> VerifiedPerson(Guid personId);
}

public enum EVerifiedPersonSearchError
{
    NoVerificationsFound = 1,
    NoReusableVerificationFound = 2,
}

public class FoundVerifiedPerson
{
    public Guid? Id { get; }
    public EVerifiedPersonSearchError? Error { get; }

    public bool HasError => Error != null;

    public FoundVerifiedPerson(Guid verifiedPersonId)
    {
        Id = verifiedPersonId;
    }
    
    public FoundVerifiedPerson(EVerifiedPersonSearchError error)
    {
        Id = null;
        Error = error;
    }
}
public class ReusablePersonVerificationService(
    IPersonsVerificationsStorageService _storage,
    ILogger<ReusablePersonVerificationService> _logger) : IReusablePersonVerificationService
{
    public async Task<FoundVerifiedPerson> VerifiedPerson(Guid personId)
    {
        var verifications = (await _storage.GetByPersonIds([personId]))
            .Where(x => x.VerificationType.IsValidVerificationType())
            .OrderByDescending(x => x.ModifiedAt ?? x.CreatedAt)
            .ToArray();

        if (verifications.Length == 0)
        {
            return new FoundVerifiedPerson(EVerifiedPersonSearchError.NoVerificationsFound);
        }

        if (verifications.First().IsSumSub())
        {
            return new FoundVerifiedPerson(personId);
        }

        var reusableVerification = verifications
            .FirstOrDefault(x => x.VerificationType.IsReusableVerificationType());

        if (reusableVerification is null)
        {
            return new FoundVerifiedPerson(EVerifiedPersonSearchError.NoReusableVerificationFound);
        }

        var verifiedPersonId = reusableVerification.InitiatorMetadata.GetPropertyOrDefault<Guid>(MetadataKeys.VerifiedPersonId);
        if (verifiedPersonId == Guid.Empty)
        {
            _logger.Warning($"Verified VerifiedPersonId is empty, verifiedPersonId: {personId}.");
            return new FoundVerifiedPerson(personId);
        }

        return new FoundVerifiedPerson(verifiedPersonId);
    }
}
*/