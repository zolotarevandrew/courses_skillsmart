namespace OOAP2.lesson13
{
    public class ParentAction
    {
        public void Approve()
        {
            
        }

        public void Decline()
        {
            
        }

        protected void Process()
        {
            
        }
    }

    public class NewAction : ParentAction
    {
        protected new void Decline()
        {
            
        }
    }
    
    public static class Lesson13Program
    {
        public static void Main(string[] args)
        {
            var action = new ParentAction();
            var newAction = new NewAction();
            
            //1 метод публичен в родительском классе А и публичен в его потомке B
            action.Approve();
            newAction.Approve();

            //4 метод скрыт в родительском классе А и скрыт в его потомке B
            //action.Process();
            //newAction.Process();
            
            //2 метод публичен в родительском классе А и скрыт в его потомке B (Decline) - возможно только полностью переопределить поведение метода, но не скрыть его полностью
            action.Decline();
            newAction.Decline();
            
        }
    } 
}