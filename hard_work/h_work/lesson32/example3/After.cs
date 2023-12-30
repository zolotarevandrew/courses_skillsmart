namespace h_work.lesson32.example3;


public class PrimaryCarriageContract
{
    public DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public DateTime AdditionalContractDate { get; init; }
    public PrimaryCarriageContractNumber Number { get; init; }

    public PrimaryCarriageContract(StatementPeriodType statementPeriod, PrimaryCarriageContractNumber number)
    {
        var now = DateTime.UtcNow.Date;
        
        StartDate = now;
        AdditionalContractDate = now;
        EndDate = EndDateByPeriod(statementPeriod);
        Number = number;
    }
    
    DateTime EndDateByPeriod(StatementPeriodType statementPeriod)
    {
        return statementPeriod switch
        {
            StatementPeriodType.HalfYear => StartDate.AddMonths(7),
            StatementPeriodType.Year => StartDate.AddMonths(9),
            StatementPeriodType.TwoYears => StartDate.AddMonths(18),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

public class CarriageContract
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? AdditionalContractDate { get; set; }
    public string? Number { get; set; }
    
    public void FillFromPrimary(PrimaryCarriageContract primary)
    {
        StartDate = primary.StartDate;
        EndDate = primary.EndDate;
        AdditionalContractDate = primary.AdditionalContractDate;
        Number = primary.Number.Value;
    }
}

public class PrimaryCarriageContractNumber
{
    private const int MinValue = 1000;
    private const int MaxValue = 9999;
    
    public PrimaryCarriageContractNumber(string carriageNumberMask)
    {
        if (string.IsNullOrEmpty(carriageNumberMask)) throw new InvalidOperationException("Mask is empty");
        
        var random = new Random(Guid.NewGuid().GetHashCode());
        var randomNumberForMask = random.Next(MinValue, MaxValue);
        Value = carriageNumberMask.Replace("{код}", randomNumberForMask.ToString());
    }
    
    public string Value { get; }
}

public class FillCarriageContractV2
{
    private readonly IStatementRepository _repository;
    private readonly IContragentRepository _contragentRepository;

    public FillCarriageContractV2(IStatementRepository repository, IContragentRepository contragentRepository)
    {
        _repository = repository;
        _contragentRepository = contragentRepository;
    }
    
    public async Task<Result> ExecuteAsync(string statementId)
    {
        var statement = await _repository.GetById(statementId);
        var contragent = await _contragentRepository.GetById(statement.ApplicantId);
        if (string.IsNullOrEmpty(contragent.CarriageNumberMask))
        {
            return Result<string>.Failed("Заполните маску Договора Перевозки в контрагенте");
        }

        var number = new PrimaryCarriageContractNumber(contragent.CarriageNumberMask);
        var primary = new PrimaryCarriageContract(statement.Period, number);
        statement.CarriageContract.FillFromPrimary(primary);
        await _repository.UpdateCarriageAsync(statement);

        return Result.Ok();
    }
}