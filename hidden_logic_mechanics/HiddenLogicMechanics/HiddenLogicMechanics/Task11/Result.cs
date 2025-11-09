using System.Globalization;

namespace HiddenLogicMechanics.Task11;

/*
 * Ранее было много императивного кода для работы с путем к универсальной анкете.
 * Переделываем на функциональный стиль.
 */
public readonly record struct UniversalSurveyPath
{
    private const char Separator = '.';
    public string Value { get; }

    private UniversalSurveyPath( string value )
    {
        ArgumentNullException.ThrowIfNull( value );
        Value = value;
    }

    public static UniversalSurveyPath Empty = new UniversalSurveyPath( string.Empty );

    public static UniversalSurveyPath FromUshort( ushort value )
    {
        return new UniversalSurveyPath( value.ToString( CultureInfo.InvariantCulture ) );
    }

    public static UniversalSurveyPath FromUshortArray( ushort[] value )
    {
        return value.Aggregate( Empty, ( current, item ) => current.MergeWith( FromUshort( item ) ) );
    }

    public UniversalSurveyPath MergeWith( UniversalSurveyPath other )
    {
        if ( string.IsNullOrEmpty( other.Value ) ) return this;
        if ( string.IsNullOrEmpty( Value ) ) return new UniversalSurveyPath( other.Value );
        return new UniversalSurveyPath( $"{Value}{Separator}{other.Value}" );
    }
}