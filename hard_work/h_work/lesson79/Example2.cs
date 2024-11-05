namespace h_work.lesson79;

public class Example2
{
    /*
     public string PositionBefore
        {
            get
            {
                if (string.IsNullOrEmpty(LastName?.Value)) return "";
                if (string.IsNullOrEmpty(FirstName?.Value)) return "";
                if (string.IsNullOrEmpty(Patronymic?.Value)) return "";
                
                var patronymic = Patronymic?.Value ?? string.Empty;
                var splitted = patronymic.Split(" ");
                
                //если отчетство длинное возвращаем полное фио просто
                if (splitted.Length > 1)
                {
                    return Fio;
                }
                
                var position = string.IsNullOrEmpty(patronymic)
                    ? $"{LastName.Value} {FirstName.Value[0]}."
                    : $"{LastName.Value} {FirstName.Value[0]}.{patronymic[0]}.";

                return position;
            }
        }
     */
}