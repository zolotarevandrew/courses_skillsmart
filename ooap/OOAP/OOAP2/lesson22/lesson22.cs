namespace OOAP2.lesson22;

//наследование видов
//заявка на пропуск достаточно сложная вещь
//и для подачи необходим документ договор перевозки CarriageContract, он может быть различных типов с разным набором полей (Международный, Дневной, Ночной, ) 
//также важный параметр сам пропуск Pass (Международный, Годовой Дневной, Годовой Ночной, Временный Дневной, Временный Ночной)
// CarriageContract и Pass часто используются по проекту как отдельные АТД, со своим набором операций, а также могут комбинироваться в рамках заявки на пропуск

//заявка на пропуск
public class ApplyForPass
{
    public CarriageContract CarriageContract { get; init; }
    public Pass Pass { get; init; }
}

//пропуск
public abstract class Pass
{
    //public abstract bool CanApply() - можно ли подать
    //и тд.
}

public class DailyAnnualPass
{
    
}

public class NightlyAnnualPass
{
    
}

//договор перевозки
public abstract class CarriageContract
{
    //public abstract decimal GetVolume()
    //public abstract void WriteToStream(Stream stream)
    //и тд.
}

public class NightCarriageContract : CarriageContract
{
    
}

public class InternationalCarriageContract : CarriageContract
{
    
}