namespace h_work.lesson18.part2.example2;

public record CrmVehicle(string Id, string Number)
{
    public const string MosTransitIgnoreId = "00000000";
        
    public void Validate(string carNumber)
    {
        if (Id == MosTransitIgnoreId) 
            return;
            
        if (Number.ToUpperInvariant() != carNumber.ToUpperInvariant())
        {
            throw new InvalidOperationException($"Номер ТС из CRM {Number}, номер переданной машины {carNumber}");
        }
    }
}
public record CreateCrmTimePass(string CarNumber, string CrmId, DateTime StartDate, DateTime EndDate, string Comment);

public interface ICrmVehicleClient
{
    Task<CrmVehicle> Get(string id);
    Task CreateTimePass(CreateCrmTimePass crmVehicle);
}

public class CrmVehicleClient : ICrmVehicleClient
{
    public Task<CrmVehicle> Get(string id)
    {
        throw new NotImplementedException();
    }

    public async Task CreateTimePass(CreateCrmTimePass rq)
    {
        var vehicle = await Get(rq.CrmId);
        vehicle?.Validate(rq.CarNumber);
       //other logic was here
    }
}