namespace h_work.lesson18.part1.example1;

public class UserInfo {}
public class RequestClientInfo
{
    public string UserAgent { get; set; }
}

public interface IActionResult
{

}

public interface IOSParser
{
    string ParseOS(string userAgent);
}
public class Example1
{
    private readonly IOSParser _parser;

    public Example1(IOSParser parser)
    {
        _parser = parser;
    }

    public async Task<IActionResult> Redirect(string id, UserInfo user, RequestClientInfo clientInfo)
    {
        var os = _parser.ParseOS(clientInfo.UserAgent);
        if (os?.ToUpper() == "ANDROID"
            || os?.ToUpper() == "IOS")
        {
            //return redirect
            return null;
        }

        return null;
    }
}