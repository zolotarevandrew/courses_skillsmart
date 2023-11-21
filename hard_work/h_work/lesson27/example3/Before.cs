namespace h_work.lesson27.example3
{
}

public interface IVerificationLinkBuilder
{
    IVerificationLinkBuilder WithLevelName(string levelName);
    IVerificationLinkBuilder WithAction(string action);
    IVerificationLinkBuilder WithPersonId(Guid personId);
    IVerificationLinkBuilder WithAdditionalParam(string key, string value);
    VerificationLink Build();
}

public record VerificationLink(string Value);