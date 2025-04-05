namespace h_work.lesson98;

/*
public static IndividualContragentDto ToIndividualContragentDto(this Contragent agent)
{
    var contragent = agent as IndividualContragent;
    return new IndividualContragentDto
    {
        FirstName = contragent.FirstName?.Value ?? string.Empty,
        LastName = contragent.LastName?.Value ?? string.Empty,
        Patronymic = contragent.Patronymic?.Value ?? string.Empty,

        PassportSerial = contragent.PassportSerial?.Value ?? string.Empty,
        PassportAddress = contragent.PassportAddress ?? string.Empty,
        PassportIssued = contragent.PassportIssued ?? string.Empty,

        PassportCode = contragent.PassportCode?.Value ?? string.Empty,
        PassportNumber = contragent.PassportNumber?.Value ?? string.Empty,
        PassportYear = contragent.PassportYear?.Value ?? string.Empty,
        BirthDate = contragent.BirthDate?.ToString(StringConsts.Date.DefaultFormat) ?? string.Empty,

        Sign = contragent.Sign.ToNullFileValueDto(),
        Passport = contragent.Passport.ToNullFileValueDto(),
        Fines = contragent.Fines?.OrderBy(f => f.IsCritical).ThenBy(f => f.Date).Select(f => new IndividualContragentFineDto
        {
            Amount = f.Amount,
            Article = f.Article,
            Details = f.Details,
            IsCritical = f.IsCritical,
            Source = f.Source.ToText(),
            Date = f.Date?.ToString(StringConsts.Date.FullFormat) ?? string.Empty,
            Created = f.Created?.ToString(StringConsts.Date.FullFormat) ?? string.Empty
        }).ToList() ?? new List<IndividualContragentFineDto>()
    };
}
*/