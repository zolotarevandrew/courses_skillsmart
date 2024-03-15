
public class ComplexLegalFormComplexityServiceTests
{
    private readonly ComplexLegalFormComplexityService _service;
    private readonly ICompanyDossierStorageService _dossier;
    private readonly ComplexLegalFormConfig _config;

    private const string ComplexLegalForm = "1";

    public ComplexLegalFormComplexityServiceTests()
    {
        _config = new ComplexLegalFormConfig
        {
            LegalForms = new List<string>
            {
                ComplexLegalForm
            }
        };
        _dossier = Mock.Resolve<ICompanyDossierStorageService>();
        _service = new ComplexLegalFormComplexityService(_dossier, _config); 
    }

    [Fact]
    public async Task Calculate_NotComplexLegalForm_NotSuccess()
    {
        var companyId = Guid.NewGuid();
        _dossier.Get(Arg.Is(companyId)).Returns(Fixture.Create<CompanyInStorage>());

        var result = await _service.Calculate(companyId);

        Assert.False(result.IsComplex);
    }

    [Fact]
    public async Task Calculate_ComplexOldLegalForm_Success()
    {
        var companyId = Guid.NewGuid();
        var fixt = Fixture.Create<CompanyInStorage>();
        fixt.Metadata = JObject.FromObject(new
        {
            OldLegalForm = Guid.Parse(ComplexLegalForm)
        });
        _dossier.Get(Arg.Is(companyId)).Returns(fixt);

        var result = await _service.Calculate(companyId);

        Assert.True(result.IsComplex);
    }

    [Fact]
    public async Task Calculate_ComplexLegalForm_Success()
    {
        var companyId = Guid.NewGuid();
        var fixt = Fixture.Create<CompanyInStorage>();
        fixt.LegalFormId = Guid.Parse(ComplexLegalForm);
        _dossier.Get(Arg.Is(companyId)).Returns(fixt);

        var result = await _service.Calculate(companyId);

        Assert.True(result.IsComplex);
    }
}
