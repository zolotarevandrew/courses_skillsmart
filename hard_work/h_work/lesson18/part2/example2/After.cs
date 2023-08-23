namespace h_work.lesson18.part2.example2;

public record CrmVehicleV2(string Id, string Number);
public record CreateCrmTimePassV2(string CarNumber, DateTime StartDate, DateTime EndDate, string Comment);

public enum CrmTimePassCreationResult
{
    InvalidCarNumber = 1,
    IgnoredMostransitId = 2,
    Ok = 3
}

public interface ICrmVehicleClientV2
{
    Task<CrmVehicleV2> Get(string id);
    Task<CrmTimePassCreationResult> CreateTimePass(CrmVehicleV2 vehicle, CreateCrmTimePassV2 request);
}

public class CrmVehicleClientV2 : ICrmVehicleClientV2
{
    public const string MosTransitIgnoreId = "00000000";
    
    public Task<CrmVehicleV2> Get(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<CrmTimePassCreationResult> CreateTimePass(CrmVehicleV2 vehicle, CreateCrmTimePassV2 request)
    {
        if (vehicle.Number.ToUpperInvariant() != request.CarNumber.ToUpperInvariant())
            return CrmTimePassCreationResult.InvalidCarNumber;
        if (vehicle.Id == MosTransitIgnoreId) return CrmTimePassCreationResult.IgnoredMostransitId;

        //logic was here
        
        return CrmTimePassCreationResult.Ok;
    }
}