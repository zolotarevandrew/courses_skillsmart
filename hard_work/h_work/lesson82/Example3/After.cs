namespace h_work.lesson82.Example3;

public class After
{
    public void Method(CompanyTaxInfoDataPointInit init, string countryCode)
    {
        var companyMainTaxNumber = init.GetMain(countryCode);
        companyMainTaxNumber.Match(
            some: taxNumber => { },
            none: () => { }
        );
    }

    public class CompanyTaxInfoDataPointInit
    {

        private List<CompanyTaxResidence> _companyTaxNumbers;

        public CompanyTaxInfoDataPointInit(IEnumerable<CompanyTaxResidence> taxResidences)
        {
            _companyTaxNumbers = taxResidences.ToList();
        }

        public Option<CompanyTaxResidence> GetMain(string countryCode)
        {
            var result = _companyTaxNumbers
                .FirstOrDefault(x => x.Country == countryCode && x.IsMain);
            return result != null ? Option<CompanyTaxResidence>.Some(result) : Option<CompanyTaxResidence>.None();
        }
    }

    public class CompanyTaxResidence
    {
        public bool IsMain { get; set; }
        public string Country { get; set; }
    }

    public class Option<T>
    {
        private readonly T _value;

        public bool HasValue { get; }
        public T Value => HasValue ? _value : throw new InvalidOperationException("No value present");

        private Option(T value, bool hasValue)
        {
            _value = value;
            HasValue = hasValue;
        }

        public static Option<T> Some(T value) => new(value, true);
        public static Option<T> None() => new(default!, false);

        public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
            => HasValue ? some(_value) : none();

        public void Match(Action<T> some, Action none)
        {
            if (HasValue) some(_value);
            else none();
        }
    }


}