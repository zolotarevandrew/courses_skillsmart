namespace h_work.lesson72;

public class Example1
{
    /*
     private async Task<TResult> ExecuteSignerOperation<TResult>(DocumentsSignerId signerId,
        Func<SigningProcess, SignerEntity, Task<TResult>> action)
    {
        var process = await _storage.GetByIdOrThrow(signerId.ProcessId);
        using var __ = DocumentSigningExecutionContext.Create(process, signerId);
        
        var signer = await _storage.GetSignerOrThrow(signerId.ProcessId, signerId.SignerId);
        if (signer.Status == DocumentSignerStatus.Signed)
            throw new ContractValidationException("Already signed");

        return await action(process, signer);
    }
     */
}