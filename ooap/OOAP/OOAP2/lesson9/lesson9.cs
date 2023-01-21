using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeepEqual.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOAP2.lesson8;

namespace OOAP2.lesson9
{
    public abstract record General
    {
        public void CopyTo(General copyTo)
        {
            CopyToInternal(this, copyTo);
        }


        public General ShallowClone()
        {
            //record feature shallow clone
            //there is no correct generic implementation of deep clone
            return this with { };
        }

        public bool EqualTo(General other)
        {
            //using library
            return this.IsDeepEqual(other);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void Deserialize(string str)
        {
            JsonConvert.PopulateObject(str, this);
        }

        public string Print()
        {
            return Serialize().Replace("\"", "");
        }

        public string Type()
        {
            return GetType().Name;
        }

        private static void CopyToInternal(object from, object copyTo)
        {
            var fromProperties = from.GetType().GetProperties();
            var toProperties = copyTo.GetType().GetProperties();

            foreach (var fromProperty in fromProperties)
            {
                foreach (var toProperty in toProperties)
                {
                    if (fromProperty.Name == toProperty.Name && fromProperty.PropertyType == toProperty.PropertyType)
                    {
                        toProperty.SetValue(copyTo, fromProperty.GetValue(from));
                        break;
                    }
                }
            }
        }
    }

    public record Any : General
    {
        
    }

    public record User : Any
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Roles { get; set; } = new();
    }
    
    public static class Lesson9Program
    {
        public static void Main(string[] args)
        {
            var user = new User
            {
                FirstName = "Andrey",
                LastName = "Zolotarev",
                Roles = new List<string>
                {
                    "Lead",
                    "Developer"
                }
            };
            
            //will be {FirstName:Andrey,LastName:Zolotarev,Roles:[Lead,Developer]}
            Console.WriteLine(user.Print());

            var newUser = new User();
            user.CopyTo(newUser);
            
            //will be {FirstName:Andrey,LastName:Zolotarev,Roles:[Lead,Developer]}
            Console.WriteLine(newUser.Print());

            //will be {"FirstName":"Andrey","LastName":"Zolotarev","Roles":["Lead","Developer"]}
            Console.WriteLine(user.Serialize());


            var deserialized = new User();
            deserialized.Deserialize(new User
            {
                FirstName = "Name",
                LastName = "Last",
                Roles = new List<string>
                {
                    "Developer"
                }
            }.Serialize());
            
            //{FirstName:Name,LastName:Last,Roles:[Developer]}
            Console.WriteLine(deserialized.Print());
            
            //User
            Console.WriteLine(deserialized.Type());

            //false
            Console.WriteLine(deserialized.EqualTo(user));
            
            //true
            Console.WriteLine(user.EqualTo(newUser));
            
            var shallowClone = user.ShallowClone();
            //{FirstName:Andrey,LastName:Zolotarev,Roles:[Lead,Developer]}
            Console.WriteLine(shallowClone.Print());

        }
    } 
}