using System;

namespace OOAP2.lesson12
{
    public abstract class Global
    {

        public TTarget AssignAttempt<TTarget>() 
            where TTarget : Global
        {
            if (typeof(TTarget) == GetType())
            {
                return this as TTarget;
            }

            return null;
        }
    }

    public class Any : Global
    {
        
    }

    public class User : Any
    {
        public string Name { get; set; }
    }

    public class Employee : Any
    {
        public string Name { get; set; }
    }

    public static class Lesson12Program
    {
        public static void Main(string[] args)
        {
            var user = new User
            {
                Name = "User1"
            };
            
            var user2 = user.AssignAttempt<User>();
            Console.WriteLine(user2.Name);

            var employee = user.AssignAttempt<Employee>();
            if (employee is null) Console.WriteLine("not success");
            
        }
    } 
}