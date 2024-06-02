namespace h_work.lesson55.Example2;

/*
 * public record OnboardingPerson
{
    protected OnboardingPersonEntity Base { get; }
    protected JObject Metadata => Base.Metadata;

    public Guid Id { get; init; }
    public Guid? UserId { get; init; }
    public Guid OnboardingId { get; init; }
    
    //other fields
    
    public OnboardingLegalRepresentative AsLegal()
    {
        if (Base?.IsLegalRepresentative != true) return null;
        var metadata = Metadata.ToObject<FinomLegalMetadata>();

        return new OnboardingLegalRepresentative(this)
        {
            Position = Base.Title,

            Shares = Base.Share,
            CountryCode = Base.Country,

            TypeOfRepresentation = metadata.TypeOfRepresentation
        };
    }
}

public record OnboardingLegalRepresentative : OnboardingPerson
{
    public decimal? Shares { get; init; }
    public string CountryCode { get; init; }
    public string Position { get; init; }
    public ETypeOfLegalRepresentation TypeOfRepresentation { get; init; }

    public OnboardingLegalRepresentative(OnboardingPerson person) : base(person)
    {

    }

    //for tests only
    public OnboardingLegalRepresentative()
    {

    }
}


*/