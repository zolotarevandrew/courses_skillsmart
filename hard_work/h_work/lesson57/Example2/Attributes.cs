namespace h_work.lesson57.Example2;



public class ApiVersionAttribute : Attribute
{
    public string Version { get; }

    public ApiVersionAttribute(string version)
    {
        Version = version;
    }
}

public class RequiredFieldAttribute : Attribute
{

    public RequiredFieldAttribute()
    {
       
    }
}

[ApiVersion("1.0.0")]
public class ContractV1
{
    [RequiredField]
    public string Name { get; set; }
    
    [RequiredField]
    public string V1Field { get; set; }
}

[ApiVersion("1.0.1")]
public class ContractV101
{
    [RequiredField]
    public string Name { get; set; }
    
    [RequiredField]
    public string V2Field { get; set; }
}