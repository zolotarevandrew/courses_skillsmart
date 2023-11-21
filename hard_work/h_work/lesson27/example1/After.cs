using System.Runtime.CompilerServices;

namespace h_work.lesson27.example1;

public enum PersonVerificationStateMoveStatus
{
    None = 0,
    NotSupported = 1,
    Ok = 2,
}

public abstract class PersonVerificationState
{
    public Guid PersonId { get; init; }
    protected PersonVerificationState(Guid personId)
    {
        PersonId = personId;
    }
    
    public PersonVerificationStateMoveStatus MoveStatus { get; private set; } = PersonVerificationStateMoveStatus.None;
    public object AdditionalData { get; private set; }

    public void TryMove(PersonVerificationState toState, object additionalData = null)
    {
        var canMoveFrom = toState.CanMoveFrom(this);
        if (!canMoveFrom)
        {
            MoveStatus = PersonVerificationStateMoveStatus.NotSupported;
            return;
        }

        MoveStatus = PersonVerificationStateMoveStatus.Ok;
        AdditionalData = additionalData;
    }

    public abstract EPersonVerificationState Current { get; }
    protected abstract bool CanMoveFrom(PersonVerificationState personVerificationState);
}

public class NewPersonVerificationState : PersonVerificationState
{
    public override EPersonVerificationState Current => EPersonVerificationState.Created;
    protected override bool CanMoveFrom(PersonVerificationState personVerificationState)
    {
        return personVerificationState.Current == EPersonVerificationState.Pending;
    }

    public NewPersonVerificationState(Guid personId) : base(personId)
    {
    }
}

public class InProgressVerificationState : PersonVerificationState
{
    public override EPersonVerificationState Current => EPersonVerificationState.InProgress;
    protected override bool CanMoveFrom(PersonVerificationState personVerificationState)
    {
        return personVerificationState.Current == EPersonVerificationState.Created;
    }

    public InProgressVerificationState(Guid personId) : base(personId)
    {
    }
}

public class PendingVerificationState : PersonVerificationState
{
    public override EPersonVerificationState Current => EPersonVerificationState.Pending;
    protected override bool CanMoveFrom(PersonVerificationState personVerificationState)
    {
        return personVerificationState.Current == EPersonVerificationState.InProgress;
    }

    public PendingVerificationState(Guid personId) : base(personId)
    {
    }
}

public class ErrorVerificationState : PersonVerificationState
{
    public override EPersonVerificationState Current => EPersonVerificationState.Failed;
    protected override bool CanMoveFrom(PersonVerificationState personVerificationState)
    {
        return personVerificationState.Current == EPersonVerificationState.Pending;
    }

    public ErrorVerificationState(Guid personId) : base(personId)
    {
    }
}

public class SuccessVerificationState : PersonVerificationState
{
    public override EPersonVerificationState Current => EPersonVerificationState.Success;
    protected override bool CanMoveFrom(PersonVerificationState personVerificationState)
    {
        return personVerificationState.Current == EPersonVerificationState.Pending;
    }

    public SuccessVerificationState(Guid personId) : base(personId)
    {
    }
}

public class RepeatVerificationState : PersonVerificationState
{
    public override EPersonVerificationState Current => EPersonVerificationState.Repeat;
    protected override bool CanMoveFrom(PersonVerificationState personVerificationState)
    {
        return personVerificationState.Current == EPersonVerificationState.Pending;
    }

    public RepeatVerificationState(Guid personId) : base(personId)
    {
    }
}

public interface IPersonVerificationStateProvider
{
    Task<PersonVerificationState> Create(IBankOnboardingContext context, FinomCreatePersonVerification request, [CallerMemberName] string source = "");
    Task<PersonVerificationState> Current(IBankOnboardingContext context, Guid personId);
    Task<PersonVerificationStateMoveStatus> MoveFrom(
        IBankOnboardingContext context, 
        PersonVerificationState fromState, 
        PersonVerificationState toState, 
        object additionaParam = null);
}

public class PersonVerificationStateProvider : IPersonVerificationStateProvider
{
    public Task<PersonVerificationState> Create(IBankOnboardingContext context, FinomCreatePersonVerification request, string source = "")
    {
        var state = new NewPersonVerificationState(request.PersonId);
        return SaveState(context, state);
    }

    public Task<PersonVerificationState> Current(IBankOnboardingContext context, Guid personId)
    {
        //get from db
        throw new NotImplementedException();
    }

    public async Task<PersonVerificationStateMoveStatus> MoveFrom(
        IBankOnboardingContext context, 
        PersonVerificationState fromState, 
        PersonVerificationState toState, 
        object additionaParam = null)
    {
        fromState.TryMove(toState, additionaParam);
        if (fromState.MoveStatus != PersonVerificationStateMoveStatus.Ok) return fromState.MoveStatus;

        await SaveState(context, toState);
        return fromState.MoveStatus;
    }
    
    
    private async Task<PersonVerificationState> SaveState(IBankOnboardingContext context, PersonVerificationState state)
    {
        throw new NotImplementedException();
    }
}



public class Example
{
    private readonly IPersonVerificationStateProvider _provider;

    public Example(IPersonVerificationStateProvider provider)
    {
        _provider = provider;
    }

    public async Task Execute()
    {
        var personId = Guid.NewGuid();
        IBankOnboardingContext context = null;
        var created = await _provider.Create(context, new FinomCreatePersonVerification());

        var current = await _provider.Current(context, personId);

        var inProgressState = new InProgressVerificationState(personId);
        var moveStatus = await _provider.MoveFrom(context, current, inProgressState);
        if (moveStatus != PersonVerificationStateMoveStatus.Ok)
        {
            //log or return some error
        }
        
        
    }
}