namespace h_work.lesson79;

public class Example5
{
    /*
      public async Task Initialize(DataPointInitializingContext context)
    {
        var stored = await Dependencies.DataPointStorageService.GetOrNull<TInit, TSubmit>(context.DataPointId);
        if (stored.Status == EDataPointStatus.Completed) return;

        var result = await GetInitData(context);

        await Dependencies.DataPointStorageService.Init(stored.Id, result);

        await TryAutoComplete(context, stored, result);
    }
     */
}