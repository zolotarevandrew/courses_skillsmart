namespace HiddenLogicMechanics.Task12;

public interface IShortAnswerInfoConverter
{
    ShortAnswerDto Convert( ShortAnswerInfo answerInfo );
}

public class Answer
{
    public SurveyKind SurveyKind { get; init; }
}
public class ShortAnswerInfo( Answer answer, KeyValuePair<string, string>[] parameters )
{
    public Answer Answer { get; set; } = answer;
    public KeyValuePair<string, string>[] Parameters { get; set; } = parameters;
}

public class ShortAnswerDto
{
}

public class FeedbackShortAnswerInfoConverter : IShortAnswerInfoConverter
{
    public ShortAnswerDto Convert( ShortAnswerInfo answerInfo )
    {
        return new ShortAnswerDto(  );
    }
}

public class NoneShortAnswerInfoConverter : IShortAnswerInfoConverter
{
    public ShortAnswerDto Convert( ShortAnswerInfo answerInfo )
    {
        return new ShortAnswerDto(  );
    }
}

public class UniversalSurveyShortAnswerInfoConverter : IShortAnswerInfoConverter
{
    public ShortAnswerDto Convert( ShortAnswerInfo answerInfo )
    {
        return new ShortAnswerDto(  );
    }
}

public enum SurveyKind
{
    Feedback,
    Universal
}

public class Usage
{
    /*
     * Простейший полиморфизм без DI, для разных типов анкет в рамках слоя контроллера.
     */
    public static void Main( )
    {
        Dictionary<SurveyKind, IShortAnswerInfoConverter> converters =
            new Dictionary<SurveyKind, IShortAnswerInfoConverter>
            {
                { SurveyKind.Feedback, new FeedbackShortAnswerInfoConverter( ) },
                { SurveyKind.Universal, new UniversalSurveyShortAnswerInfoConverter( ) }
            };
        NoneShortAnswerInfoConverter noneConverter = new NoneShortAnswerInfoConverter( );

        ShortAnswerInfo[] answers = [];
        ShortAnswerDto[] res = answers
            .Select( i => converters.TryGetValue( i.Answer.SurveyKind, out IShortAnswerInfoConverter? converter )
                ? converter.Convert( i )
                : noneConverter.Convert( i ) )
            .ToArray( );
    }
}


