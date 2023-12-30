namespace h_work.lesson32.example3;

public enum StatementPeriodType
{
    HalfYear,
    Year,
    TwoYears
}

public class Statement
{
    public string ApplicantId { get; }
    public StatementPeriodType Period { get; }
    public CarriageContract CarriageContract { get; }
}

public interface IStatementRepository
{
    Task<Statement> GetById(string id);
    Task UpdateCarriageAsync(Statement statement);
}

public class FillCarriageContract
{
    private readonly IStatementRepository _repository;
    private readonly IContragentRepository _contragentRepository;

    public FillCarriageContract(IStatementRepository repository, IContragentRepository contragentRepository)
    {
        _repository = repository;
        _contragentRepository = contragentRepository;
    }

    public async Task<Result?> ExecuteAsync(string id)
    {
        var statement = await _repository.GetById(id);

        var startDate = DateTime.UtcNow.Date;

        DateTime GetEnd()
        {
            return statement.Period switch
            {
                StatementPeriodType.HalfYear => startDate.AddMonths(7),
                StatementPeriodType.Year => startDate.AddMonths(9),
                StatementPeriodType.TwoYears => startDate.AddMonths(18),
                _ => throw new ArgumentOutOfRangeException()
            };
        };
        statement.CarriageContract.StartDate = startDate;
        statement.CarriageContract.EndDate = GetEnd();
        statement.CarriageContract.AdditionalContractDate = startDate;
            
        var number = await GenerateNumber(statement.ApplicantId);
        if (number.IsError) return number;
        statement.CarriageContract.Number = number.Value;
            
        await _repository.UpdateCarriageAsync(statement);

        return Result.Ok();
    }

    async Task<Result<string>> GenerateNumber(string id)
    {
        var random = new Random(Guid.NewGuid().GetHashCode());
        var number = random.Next(1000, 9999);
        var contragent = await _contragentRepository.GetById(id);

        if (string.IsNullOrEmpty(contragent.CarriageNumberMask))
            return Result<string>.Failed("Заполните маску Договора Перевозки в контрагенте");

        var mask = contragent.CarriageNumberMask.Replace("{код}", number.ToString());
        return Result<string>.Ok(mask);
    }
}

public interface IContragentRepository
{
    Task<Contragent> GetById(string id);
}

public class Contragent
{
    public string? CarriageNumberMask { get; set; }
}

public class Result
{
    public static Result Ok()
    {
        throw new NotImplementedException();
    }
}

public class Result<T> : Result
{
    public T? Value { get; }
    public static Result<T> Ok(object mask)
    {
        throw new NotImplementedException();
    }

    public static Result<T> Failed(string error)
    {
        throw new NotImplementedException();
    }

    public bool IsError { get; set; }
}