using dnlib.PE;
using h_work.lesson18.part3.example3;
using Stateless;
using Stateless.Graph;
using Machine = Stateless.StateMachine<h_work.lesson27.example2.ETaxIdentificationStatus, string>;
using MachineConfiguration = Stateless.StateMachine<h_work.lesson27.example2.ETaxIdentificationStatus, string>.StateConfiguration;

namespace h_work.lesson27.example2;

public static class Extensions
{
    public static MachineConfiguration PermitTrigger<T>(this MachineConfiguration configuration) 
        where T: TaxIdentificationTrigger
    {
        var attribute = typeof(T)
            .GetCustomAttributes(typeof(TaxIdentificationTriggerAttribute), true)
            .FirstOrDefault() as TaxIdentificationTriggerAttribute;
        if (attribute == null) throw new InvalidOperationException($"attribute not implemented for this type {typeof(T)}");

        return configuration.PermitIf(typeof(T).Name.Replace("TaxIdentificationTrigger", ""), attribute.Status);
    }
}

public class TaxIdentificationStateMachine
{
    private Machine _machine;
    
    public ETaxIdentificationStatus State { get; private set; }

    public TaxIdentificationStateMachine(ETaxIdentificationStatus currentStatus)
    {
        State = currentStatus;
        _machine = new StateMachine<ETaxIdentificationStatus, string>(() => State,
            s => State = s);
        
        _machine.Configure(ETaxIdentificationStatus.Created)
            .PermitTrigger<CompletedTaxIdentificationTrigger>()
            .PermitTrigger<DeadlineExceededTaxIdentificationTrigger>()
            .PermitTrigger<MovedToBlockTaxIdentificationTrigger>();
        
        _machine.Configure(ETaxIdentificationStatus.DeadlineExceeded)
            .PermitTrigger<MovedToBlockTaxIdentificationTrigger>()
            .PermitTrigger<MovedForCheckTaxIdentificationTrigger>();
        
        _machine.Configure(ETaxIdentificationStatus.MovedForCheck)
            .PermitTrigger<ReRequestedTaxIdentificationTrigger>()
            .PermitTrigger<CompletedTaxIdentificationTrigger>();

        _machine.Configure(ETaxIdentificationStatus.ReRequested)
            .PermitTrigger<DeadlineExceededTaxIdentificationTrigger>();
    }

    public string Export()
    {
        return UmlDotGraph.Format(_machine.GetInfo());
    }
}

public abstract record TaxIdentificationTrigger { }

[TaxIdentificationTrigger(Status = ETaxIdentificationStatus.Completed)]
public record CompletedTaxIdentificationTrigger : TaxIdentificationTrigger { }

[TaxIdentificationTrigger(Status = ETaxIdentificationStatus.ReRequested)]
public record ReRequestedTaxIdentificationTrigger : TaxIdentificationTrigger { }

[TaxIdentificationTrigger(Status = ETaxIdentificationStatus.DeadlineExceeded)]
public record DeadlineExceededTaxIdentificationTrigger : TaxIdentificationTrigger { }

[TaxIdentificationTrigger(Status = ETaxIdentificationStatus.MovedToBlock)]
public record MovedToBlockTaxIdentificationTrigger : TaxIdentificationTrigger { }

[TaxIdentificationTrigger(Status = ETaxIdentificationStatus.MovedForCheck)]
public record MovedForCheckTaxIdentificationTrigger : TaxIdentificationTrigger { }

public class TaxIdentificationTriggerAttribute : Attribute
{
    public ETaxIdentificationStatus Status { get; set; }
}

public enum ETaxIdentificationStatus
{
    Created,
    Completed,
    DeadlineExceeded,
    MovedToBlock,
    MovedForCheck,
    ReRequested
}


public interface ITaxIdentificationServiceV2
{
    Task<FinomTaxIdentificationStatus> GetStatus(FinomTaxIdentificationContext context);
    Task Start(FinomTaxIdentificationContext context);
    
    //здесь будем использовать стейт машину и переводить в нужный стейт, библиотека сама выдаст ошибку,
    //если вдруг что-то пойдет не так, мы ее обернем в кастомную ошибку или тип результата.
    Task Changed(TaxIdentificationTrigger trigger);
}