using h_work.lesson1.example3;

var r = new RiskLevelRefCalculator(new List<DictionaryItem>(), new List<RiskLevelItem>());
var riskSource = RiskSourceFactory.FromSource(new RiskSource
{
    Value = "1"
});
r.Calc(riskSource);