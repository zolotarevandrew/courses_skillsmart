using Newtonsoft.Json.Linq;

namespace h_work.lesson69;

public enum EDocumentField
{
    SpainNifNumber,
    ItalyCodiceFiscale,
}

public readonly struct DocumentField
{
    public EDocumentField? Field { get; }
    private readonly JToken _value;

    public DocumentField(string countryCode, string fieldName, JToken value)
    {
        Field = MapField(countryCode, fieldName);
        _value = value;
    }

    public bool IsEligible =>
        _value.Type is JTokenType.Integer or
            JTokenType.Float or
            JTokenType.String or
            JTokenType.Boolean or
            JTokenType.Date or
            JTokenType.Guid or
            JTokenType.TimeSpan;

    private static EDocumentField? MapField(string countryCode, string fieldName) =>
        (countryCode, fieldName) switch
        {
            ("ES", "additionalNumber") => EDocumentField.SpainNifNumber,
            ("IT", "barcodeLine") => EDocumentField.ItalyCodiceFiscale,
            _ => null,
        };
}