namespace h_work.lesson79;

/*
public record DriverBirthDateValue
{
    public string Value { get; private set; }

    private DriverBirthDateValue(string value)
    {
        Value = value;
    }

    public static Result<DriverBirthDateValue> Create(string val)
    {
        if (string.IsNullOrEmpty(val)) return Result<DriverBirthDateValue>.Ok(new DriverBirthDateValue(""));
        if (!Regex.IsMatch(val, @"\d{2}\.\d{2}\.\d{4}")) return Result<DriverBirthDateValue>.Failed("Заполните дату рождения");

        return Result<DriverBirthDateValue>.Ok(new DriverBirthDateValue(val));
    }
}
*/