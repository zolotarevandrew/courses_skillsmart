namespace h_work.lesson93.Example4;

public class Before
{
    /*
    public async Task<ResultContract<Guid>> ByPersonId()
    {

         * var personId = RouteValues.GetRoute<Guid>("personId");

        var verifications = (await storage.GetByPersonIds([personId]))
            .Where(x => x.VerificationType.IsValidVerificationType())
            .OrderByDescending(x => x.ModifiedAt ?? x.CreatedAt)
            .ToArray();

        if (verifications.Length == 0)
        {
            throw new RowNullException($"No verifications found. PersonId: {personId}");
        }

        if (verifications.First().IsSumSub())
        {
            return new ResultContract<Guid>(personId);
        }

        var reusableVerification = verifications
            .FirstOrDefault(x => x.VerificationType.IsReusableVerificationType());

        if (reusableVerification is null)
        {
            throw new InvalidOperationException($"Reusable verification doesn't exist, personId: {personId}.");
        }

        var verifiedPersonId = reusableVerification
            .InitiatorMetadata.GetPropertyOrDefault<Guid>(MetadataKeys.VerifiedPersonId);

        if (verifiedPersonId == Guid.Empty)
        {
            logger.Error(new InvalidOperationException($"{nameof(verifiedPersonId)} is empty"), $"Verified PersonId is empty, personId: {personId}.");
            return new ResultContract<Guid>(personId);
        }

        return new ResultContract<Guid>(verifiedPersonId);
    }
    */
}