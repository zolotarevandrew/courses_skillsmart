using Newtonsoft.Json.Linq;

namespace h_work.lesson66;

public class Example3
{
    public static object SanitizePersonalFields(object data)
    {
        var jobj = JObject.FromObject(data);
        jobj.Remove("firstName");
        jobj.Remove("lastName");

        return jobj.ToObject<object>();
    }
}