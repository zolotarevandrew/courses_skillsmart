using System;
using System.Threading.Tasks;

namespace OOAP2.lesson8
{
    
    public abstract class BaseTaskHandler
    {
        public abstract Task Handle();
    }

    public delegate BaseTaskHandler GetTaskHandler();

    public class PrepareUserTaskHandler : BaseTaskHandler
    {
        public override async Task Handle()
        {
            Console.WriteLine("prepare user");
        }
    }
    
    public class DefaultTaskHandler : BaseTaskHandler
    {
        public override async Task Handle()
        {
            Console.WriteLine("default");
        }
    }

   


    public class Person {}
    public class LegalRep : Person {}

    public delegate void PreparePerson(Person person);
    
    
    public static class Funcs
    {
        public static PrepareUserTaskHandler PrepareUserHandler()
        {
            return new PrepareUserTaskHandler();
        }
        
        public static BaseTaskHandler DefaultHandler()
        {
            return new DefaultTaskHandler();
        }

        public static void PrepareLegalRep(LegalRep legalRep)
        {
            Console.WriteLine("legal rep prepared");
        }
        
        public static void PreparePerson(Person person)
        {
            Console.WriteLine("person prepared");
        }
    }


    public static class Lesson8Program
    {
        public static async Task Main(string[] args)
        {
            GetTaskHandler getTaskHandler1 = Funcs.DefaultHandler;
            await getTaskHandler1().Handle(); 
            
            //ковариатность
            GetTaskHandler getTaskHandler2 = Funcs.PrepareUserHandler;
            await getTaskHandler2().Handle();


            //контрвариантность
            Action<LegalRep> prepareLegalRep = Funcs.PreparePerson;
            Action<Person> preparePerson = Funcs.PreparePerson;
            
        }
    } 
}