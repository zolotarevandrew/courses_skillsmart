public interface ILegalFormGetter
{
    IEnumerable<LegalForm> Get(string countryCode);
}

public class LegalForm(string Name, string Code);