namespace OOAP2.lesson10
{
    public class General
    {
        public virtual General Clone()
        {
            return default;
        }
    }
    
    //возможно только таким хаком, когда приходится наследоваться и не давать дальше по цепочке переопределять методы
    public class SealedGeneral : General
    {
        public sealed override General Clone()
        {
            return default;
        }
    }

    public class Any : SealedGeneral
    {
        //compile error
        /*
        public override General Clone()
        {
            return default;
        }
        */
    }
}