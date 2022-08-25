let days_in_month = function 
 | month when month >= 1 && month <= 12 -> System.DateTime.DaysInMonth(System.DateTime.Now.Year, month)
 | _  -> 0