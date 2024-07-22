using Z.Linq;

namespace h_work.lesson62;

public class Example3
{
    public async Task Before()
    {
        /*
        for (int index = 0; index < beneficiaries.Count; index++)
        {
            OnboardingPersonEntity beneficiary = beneficiaries[index];
            UserContract userContract = await _kycContractHelper.GetUserContract(context, beneficiary, index);
            if (string.IsNullOrWhiteSpace(userContract.MobilePhone))
            {
                userContract.MobilePhone = registratorMobilePhoneNumber;
            }
            await kycService.UpsertUser(context, userContract);

            await KycHelper.UpdatePersonEmail(context, _bankOnboardingPersonsService,
                this, beneficiary.Id, userContract.UserEmail);
        }
        */
    }
    
    public async Task After()
    {
        /*
        await beneficiaries
            .Select(async (beneficiary, index) =>
            {
                UserContract userContract = await _kycContractHelper.GetUserContract(context, beneficiary, index);
                if (string.IsNullOrWhiteSpace(userContract.MobilePhone))
                {
                    userContract.MobilePhone = registratorMobilePhoneNumber;
                }
                await kycService.UpsertUser(context, userContract);
                await KycHelper.UpdatePersonEmail(context, _bankOnboardingPersonsService, this, beneficiary.Id, userContract.UserEmail);
            })
            .WhenAll();

        */
    }
}

public static class TaskExtensions
{
    public static Task WhenAll(this IEnumerable<Task> tasks)
    {
        return Task.WhenAll(tasks);
    }

    public static Task<TResult[]> WhenAll<TResult>(this IEnumerable<Task<TResult>> tasks)
    {
        return Task.WhenAll(tasks);
    }
}