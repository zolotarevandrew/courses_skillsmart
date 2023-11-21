
namespace h_work.lesson27.example3;

public interface IVerificationLinkBuilderStep1
{
    IVerificationLinkBuilderStep2 WithPersonId(Guid personId);
}

public interface IVerificationLinkBuilderStep2
{
    IVerificationLinkBuilderStep3 WithLevelName(string levelName);
}

public interface IVerificationLinkBuilderStep3
{
    IVerificationLinkBuilderStep3 WithAction(string action);
    IVerificationLinkBuilderStep3 WithAdditionalParam(string key, string value);
    
    VerificationLink Build();
}

public class Example
{
    public Example()
    {
        IVerificationLinkBuilder builder = null;
        var link = builder.GetBuilder()
            .WithPersonId(Guid.NewGuid())
            .WithLevelName("")
            .WithAction("")
            .WithAdditionalParam("1", "2")
            .Build();
    }
}

public interface IVerificationLinkBuilder
{
    IVerificationLinkBuilderStep1 GetBuilder();
}